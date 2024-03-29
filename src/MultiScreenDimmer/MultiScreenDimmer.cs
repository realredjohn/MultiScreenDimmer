using Microsoft.VisualBasic;
using Microsoft.Win32;
using MultiScreenDimmer;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DimScreen
{
    public partial class MultiScreenDimmer : Form
    {
        #region Platform Invocation (P/Invoke) Methods
        // Constants and external methods for manipulating window styles and positions
        private const int GWL_EXSTYLE = -20;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOSIZE = 0x0001;
        private const int HWND_TOPMOST = -1;

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        // Extended window styles enumeration
        [Flags]
        private enum ExtendedWindowStyles
        {
            WS_EX_LAYERED = 0x00080000,
            WS_EX_TRANSPARENT = 0x00000020,
            WS_EX_TOOLWINDOW = 0x00000080
        }
        #endregion

        #region Global Variables
        // Keyboard hook related variables and constants
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private IntPtr _hookID = IntPtr.Zero;
        private LowLevelKeyboardProc _proc;

        // Low-level keyboard hook callback function
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        // Necessary functions
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion


        // Application Settings
        private const string StartupRegistryKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";
        private const string AppName = "MultiScreenDimmer";

        // Overlay Windows
        private Dictionary<int, Form> _overlayWindows = new Dictionary<int, Form>();

        // Data Storage and Forms
        private DataStorage? _dataStorage;
        private AboutForm _aboutBox = new AboutForm();
        private ToolTip _toolTip = new ToolTip();

        // Monitor Information
        private List<Form> _monitorNumberForms = new List<Form>();
        private List<MonitorInfo>? _monitorInfoList;

        // Profile Information
        private List<Profile>? _profileList;
        private bool _isProfileSet = false;
        private Dictionary<Profile, List<Keys>> _profileShortcuts = new Dictionary<Profile, List<Keys>>();

        // Keyboard Input Handling
        private HashSet<Keys> _pressedKeys = new HashSet<Keys>();

        // System Tray
        private NotifyIcon? _notifyIcon;
        private ContextMenuStrip? _contextMenuStrip;
        private ToolStripMenuItem? _startupMenuItem;
        private ToolStripMenuItem? _showMenuItem;
        private ToolStripMenuItem? _exitMenuItem;

        // Application Position
        private Point _lastLocation;

        // Shortcut Popup
        private bool _isShortcutPopupOpen = false;



        public MultiScreenDimmer()
        {
            // Initialize components
            InitializeComponent();
            InitializeDataStorage();
            InitializeSystemTray();
            InitializeStartupCheckBox();
            InitializeMinimizeCheckBox();

            // Get displays and profiles
            PopulateMonitors();
            LoadProfiles();

            // Initialize the keyboard hook
            _proc = HookCallback;
            _hookID = SetHook(_proc);
        }


        // --------------------------------------------------------------------

        #region Startup Related Methods
        private void InitializeStartupCheckBox()
        {
            try
            {
                checkBoxStartup.Checked = IsStartupCheckBoxEnabled();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing startup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsStartupCheckBoxEnabled()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupRegistryKey, true))
            {
                return key.GetValue(AppName) != null;
            }
        }

        private void SetStartupCheckBox(bool enabled)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupRegistryKey, true))
                {
                    if (enabled)
                    {
                        key.SetValue(AppName, Application.ExecutablePath);
                    }
                    else
                    {
                        key.DeleteValue(AppName, false);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle registry access error
                MessageBox.Show($"Error accessing registry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxStartup_CheckedChanged(object sender, EventArgs e)
        {
            _startupMenuItem.Checked = checkBoxStartup.Checked;

            SetStartupCheckBox(checkBoxStartup.Checked);
        }
        #endregion

        #region Minimize or Close Related Methods
        private void InitializeMinimizeCheckBox()
        {
            checkBoxMinimize.Checked = _dataStorage.LoadMinimizeCheckBoxState();
        }

        private void checkBoxMinimize_CheckedChanged(object sender, EventArgs e)
        {
            _dataStorage.SaveMinimizeCheckBoxState(checkBoxMinimize.Checked);
        }
        #endregion

        #region System Tray Related Methods
        private void InitializeSystemTray()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = global::MultiScreenDimmer.Properties.Resources.msd_icon_ico_3;
            _notifyIcon.Text = "MultiScreenDimmer";
            _notifyIcon.Visible = true;

            // Context menu for the notify icon
            _contextMenuStrip = new ContextMenuStrip();

            _startupMenuItem = new ToolStripMenuItem("Start with Windows");
            _startupMenuItem.Checked = checkBoxStartup.Checked; // Sync with checkStartup
            _startupMenuItem.Click += StartupMenuItem_Click;
            _contextMenuStrip.Items.Add(_startupMenuItem);

            _contextMenuStrip.Items.Add(new ToolStripSeparator());

            _showMenuItem = new ToolStripMenuItem("Show");
            _showMenuItem.Click += ShowMenuItem_Click;
            _contextMenuStrip.Items.Add(_showMenuItem);

            _exitMenuItem = new ToolStripMenuItem("Exit");
            _exitMenuItem.Click += ExitMenuItem_Click;
            _contextMenuStrip.Items.Add(_exitMenuItem);

            _notifyIcon.ContextMenuStrip = _contextMenuStrip;

            // Handle form closing event
            _notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            FormClosing += DimScreen_FormClosing;
        }

        private void DimScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (checkBoxMinimize.Checked)
                {
                    e.Cancel = true; // Cancel the form closing event
                    HideForm(); // Hide the form instead of closing it
                }
                else
                {
                    ExitApplication();
                }
            }
        }

        private void StartupMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            menuItem.Checked = !menuItem.Checked; // Toggle the checked state
            checkBoxStartup.Checked = menuItem.Checked; // Sync with checkStartup
        }

        private void ShowMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HideForm()
        {
            Hide();
        }

        private void ShowForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }
        #endregion

        #region Data Storage Related Methods
        private void InitializeDataStorage()
        {
            string filePath = "saveData.json";
            _dataStorage = new DataStorage(filePath);
            _monitorInfoList = _dataStorage.LoadMonitorInfo();
            ReloadProfiles();
        }

        public void ReloadProfiles()
        {
            _profileList = _dataStorage.LoadProfiles();
        }
        #endregion

        #region Keyboard Hook Related Methods
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            // Check if the ShortcutPopupForm is not open
            if (!_isShortcutPopupOpen)
            {
                if (nCode >= 0 && wParam == WM_KEYDOWN)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    Keys key = (Keys)vkCode;

                    // Add the pressed key to the set
                    _pressedKeys.Add(key);

                    // Check if any profile shortcut is pressed
                    foreach (var profileShortcutPair in _profileShortcuts)
                    {
                        var profile = profileShortcutPair.Key;
                        var shortcutKeys = profileShortcutPair.Value;

                        // Check if all keys in the profile shortcut are pressed
                        if (shortcutKeys.All(_pressedKeys.Contains))
                        {
                            Dim(profile);
                            break;
                        }
                    }
                }
                else if (nCode >= 0 && wParam == WM_KEYUP)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    Keys key = (Keys)vkCode;

                    // Remove the released key from the set
                    _pressedKeys.Remove(key);
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        #endregion

        #region Profile Shortcut Related Methods
        public void PopulateProfileShortcuts()
        {
            _profileShortcuts.Clear();

            foreach (var profile in _profileList)
            {
                _profileShortcuts.Add(profile, GetKeysFromShortcut(profile));
            }
        }

        private List<Keys> GetKeysFromShortcut(Profile profile)
        {
            List<Keys> keys = new List<Keys>();

            foreach (var key in profile.Shortcut)
            {
                // Convert to Left Key for Control and Shift
                if (key == Keys.Control || key == Keys.ControlKey || key == Keys.LControlKey || key == Keys.RControlKey)
                {
                    keys.Add(Keys.LControlKey);
                }
                else if (key == Keys.Shift || key == Keys.ShiftKey || key == Keys.LShiftKey || key == Keys.RShiftKey)
                {
                    keys.Add(Keys.LShiftKey);
                }
                else
                {
                    keys.Add(key);
                }
            }

            return keys;
        }

        public void SetIsShortcutPopupOpen(bool isOpen)
        {
            _isShortcutPopupOpen = isOpen;
        }
        #endregion

        #region Window Position and Size Management
        // Override the OnLoad method to load window position and size
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadWindowPosition();
        }

        // Override the OnFormClosing event to save window position and size
        // ==>> Override OnFormClosing on Region Keyboard Hook Related Methods

        // Method to save window position and size
        private void SaveWindowPosition()
        {
            global::MultiScreenDimmer.Properties.Settings.Default.LastLocation = Location;
            global::MultiScreenDimmer.Properties.Settings.Default.Save();
        }

        // Method to load and apply window position and size
        private void LoadWindowPosition()
        {
            // Load the window's location and size
            _lastLocation = global::MultiScreenDimmer.Properties.Settings.Default.LastLocation;

            // If the location and size are valid, apply them
            if (_lastLocation != Point.Empty)
            {
                Location = _lastLocation;
            }
        }

        #endregion

        // --------------------------------------------------------------------

        #region Main Methods
        private void PopulateMonitors()
        {
            listBoxMonitors.Items.Clear();

            foreach (Screen screen in Screen.AllScreens)
            {
                if (_monitorInfoList.Count > 0)
                {
                    if (_dataStorage.IsMonitorInfoSaved(screen.WorkingArea.ToString()))
                    {
                        listBoxMonitors.Items.Add(_dataStorage.GetMonitorName(screen.WorkingArea.ToString()));
                        continue;
                    }
                }

                string numberString = MyRegex().Match(screen.DeviceName).Value;
                int monitorNumberInt;
                if (!int.TryParse(numberString, out monitorNumberInt))
                {
                    MessageBox.Show("Failed to parse monitor number.");
                    return;
                }

                string itemText = $"Display {monitorNumberInt}";
                listBoxMonitors.Items.Add(itemText);

                MonitorInfo newMonitorInfo = new MonitorInfo
                {
                    DisplayName = itemText,
                    MonitorIdentifier = screen.WorkingArea.ToString()
                };
                _dataStorage.SaveMonitorInfo(newMonitorInfo);
            }
        }

        private void LoadProfiles()
        {
            CheckAndUpdateSetProfileButton();

            // Check if profiles exist in DataStorage
            if (_profileList.Count > 0)
            {
                foreach (var profile in _profileList)
                {
                    // Extract the profile number from the profile name
                    int profileNumber;
                    if (int.TryParse(profile.ProfileName.Replace("Profile ", ""), out profileNumber))
                    {
                        // Get the corresponding profile box based on the profile number
                        ProfileBox profileBox = GetProfileBoxByIndex(profileNumber);

                        if (profileBox != null)
                        {
                            profileBox.SetProfile(profile);
                            profileBox.SetVisibles(true);
                            profileBox.SetDataStorage(_dataStorage);
                            profileBox.SetDimContent(profile.Opacity);
                            profileBox.SetDimScreen(this);

                            // Iterate over the monitor info list of the profile
                            List<int> selectedIndicesList = new List<int>();
                            foreach (var monitorInfo in profile.MonitorInfoList)
                            {
                                // Find the index of the monitor info in monitorInfoList
                                int index = _monitorInfoList.FindIndex(m => m.MonitorIdentifier == monitorInfo.MonitorIdentifier);
                                if (index != -1)
                                {
                                    // Add the index to the selectedIndicesList
                                    selectedIndicesList.Add(index);
                                }
                            }

                            // Pass the selected indices list to SetScreensContent method of profileBox
                            profileBox.SetScreensContent(selectedIndicesList);
                        }
                    }
                }

                PopulateProfileShortcuts();
            }
        }

        private void Dim()
        {
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                if (listBoxMonitors.SelectedIndices.Contains(i))
                {
                    Screen screen = Screen.AllScreens[i];

                    Form overlayWindow;
                    if (_overlayWindows.ContainsKey(i))
                    {
                        overlayWindow = _overlayWindows[i];
                    }
                    else
                    {
                        overlayWindow = new Form();
                        overlayWindow.FormBorderStyle = FormBorderStyle.None;
                        overlayWindow.BackColor = Color.Black;
                        overlayWindow.StartPosition = FormStartPosition.Manual;
                        overlayWindow.ShowInTaskbar = false;

                        _overlayWindows[i] = overlayWindow;
                    }

                    // Update properties of existing or newly created overlay window
                    overlayWindow.Opacity = (double)trackBarOpacity.Value / trackBarOpacity.Maximum < 0.99 ?
                                             (double)trackBarOpacity.Value / trackBarOpacity.Maximum : 0.99;
                    overlayWindow.Location = screen.Bounds.Location;
                    overlayWindow.Size = screen.Bounds.Size;

                    int extendedStyle = GetWindowLong(overlayWindow.Handle, GWL_EXSTYLE);
                    extendedStyle |= (int)ExtendedWindowStyles.WS_EX_LAYERED | (int)ExtendedWindowStyles.WS_EX_TRANSPARENT | (int)ExtendedWindowStyles.WS_EX_TOOLWINDOW;
                    SetWindowLong(overlayWindow.Handle, GWL_EXSTYLE, extendedStyle);

                    overlayWindow.Show();
                    SetWindowPos(overlayWindow.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
                }
            }

            buttonResetDim.Enabled = true;
            _isProfileSet = false;

            SetTopMost();
        }

        public void Dim(Profile profile)
        {
            if (_isProfileSet)
            {
                DisposeOverlayWindows();
                return;
            }

            foreach (var monitorInfo in profile.MonitorInfoList)
            {
                int i = _monitorInfoList.FindIndex(m => m.MonitorIdentifier == monitorInfo.MonitorIdentifier);
                if (i >= 0)
                {
                    Screen screen = Screen.AllScreens[i];

                    Form overlayWindow;
                    if (_overlayWindows.ContainsKey(i))
                    {
                        overlayWindow = _overlayWindows[i];
                    }
                    else
                    {
                        overlayWindow = new Form();
                        overlayWindow.FormBorderStyle = FormBorderStyle.None;
                        overlayWindow.BackColor = Color.Black;
                        overlayWindow.StartPosition = FormStartPosition.Manual;
                        overlayWindow.ShowInTaskbar = false;

                        _overlayWindows[i] = overlayWindow;
                    }

                    // Update properties of existing or newly created overlay window
                    double opacity = profile.Opacity / 100.0;
                    overlayWindow.Opacity = opacity < 0.99 ? opacity : 0.99;
                    overlayWindow.Location = screen.Bounds.Location;
                    overlayWindow.Size = screen.Bounds.Size;

                    int extendedStyle = GetWindowLong(overlayWindow.Handle, GWL_EXSTYLE);
                    extendedStyle |= (int)ExtendedWindowStyles.WS_EX_LAYERED | (int)ExtendedWindowStyles.WS_EX_TRANSPARENT | (int)ExtendedWindowStyles.WS_EX_TOOLWINDOW;
                    SetWindowLong(overlayWindow.Handle, GWL_EXSTYLE, extendedStyle);

                    overlayWindow.Show();
                    SetWindowPos(overlayWindow.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
                }
            }

            buttonResetDim.Enabled = true;
            _isProfileSet = true;

            SetTopMost();
        }

        private void DisposeOverlayWindows()
        {
            foreach (var window in _overlayWindows.Values)
            {
                if (window != null && !window.IsDisposed)
                {
                    window.Dispose();
                }
            }

            _overlayWindows.Clear(); // Clear the dictionary after disposing windows
            buttonResetDim.Enabled = false;
            _isProfileSet = false;

            SetTopMost();
        }

        private void ShowMonitorNumbers()
        {
            buttonIdentifyDisplays.Enabled = false;

            foreach (Screen screen in Screen.AllScreens)
            {
                MonitorNumberForm monitorNumberForm = new MonitorNumberForm(screen.DeviceName);
                monitorNumberForm.Location = new Point(screen.Bounds.Left + 50, screen.Bounds.Top + 50);
                monitorNumberForm.Show();
                _monitorNumberForms.Add(monitorNumberForm);
            }

            // Close forms after 4 seconds
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 4000;
            timer.Tick += (sender, e) =>
            {
                foreach (Form form in _monitorNumberForms)
                {
                    form.Close();
                }
                buttonIdentifyDisplays.Enabled = true;
                timer.Stop();
            };
            timer.Start();
        }

        private void SetTopMost()
        {
            TopMost = true;
        }
        #endregion

        #region Event Handlers
        private void listBoxMonitors_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxMonitors.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                // Get the current display name
                string currentItem = listBoxMonitors.Items[index].ToString();

                // Prompt the user to enter a new display name
                string newName = PromptForNewName(currentItem);

                // Update the display name if the user provided a new name
                if (!string.IsNullOrEmpty(newName))
                {
                    listBoxMonitors.Items[index] = $"[{index + 1}] {newName}";

                    // Save the changes to persistent storage
                    MonitorInfo newMonitorInfo = new MonitorInfo
                    {
                        DisplayName = $"[{index + 1}] {newName}",
                        MonitorIdentifier = Screen.AllScreens[index].WorkingArea.ToString()
                    };
                    _dataStorage.EditMonitorInfo(Screen.AllScreens[index].WorkingArea.ToString(), $"[{index + 1}] {newName}");
                }
            }
        }

        private string PromptForNewName(string currentItem)
        {
            // Remove the prefix "[x] " from the current name
            string newName = Regex.Replace(currentItem, @"^\[\d+\]\s*", "");

            // Prompt the user for a new display name
            newName = Interaction.InputBox("Enter a new display name:", "Rename Display", newName);

            return newName;
        }

        private void listBoxMonitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckAndUpdateSetProfileButton();
            CheckAndUpdateApplyDimButton();
        }

        private void buttonIdentifyDisplays_Click(object sender, EventArgs e)
        {
            ShowMonitorNumbers();
        }

        private void trackBarOpacity_Scroll(object sender, EventArgs e)
        {
            textBoxDimValue.Text = $"{trackBarOpacity.Value}";
        }

        private void trackBarOpacity_MouseHover(object sender, EventArgs e)
        {
            _toolTip.SetToolTip(trackBarOpacity, "Adjust the dim amount");
        }

        private void trackBarOpacity_ValueChanged(object sender, EventArgs e)
        {
            CheckAndUpdateApplyDimButton();
            CheckAndUpdateSetProfileButton();
        }

        private void TextBoxOpacityValue_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(textBoxDimValue.Text, out value))
            {
                if (value < 0)
                    value = 0;
                else if (value > 100)
                    value = 100;
                trackBarOpacity.Value = value;
                textBoxDimValue.Text = $"{value}";
            }
        }

        private void buttonApplyDim_Click(object sender, EventArgs e)
        {
            Dim();
        }

        private void buttonResetDim_Click(object sender, EventArgs e)
        {
            DisposeOverlayWindows();
        }

        private void buttonSetProfile_Click(object sender, EventArgs e)
        {
            // Retrieve the selected monitors
            List<MonitorInfo> selectedMonitors = new List<MonitorInfo>();
            foreach (int selectedIndex in listBoxMonitors.SelectedIndices)
            {
                Screen screen = Screen.AllScreens[selectedIndex];
                MonitorInfo monitorInfo = _dataStorage.GetMonitorInfo(screen.WorkingArea.ToString());
                selectedMonitors.Add(monitorInfo);
            }

            // Generate the profile name
            int profileIndex = _dataStorage.GetNextAvailableSlotIndex();
            string profileName = $"Profile {profileIndex}";

            // Get the opacity value from the trackBar
            int opacity = trackBarOpacity.Value;
            Keys profileSpecificKey;
            switch (profileIndex)
            {
                case 1:
                    profileSpecificKey = Keys.D1;
                    break;
                case 2:
                    profileSpecificKey = Keys.D2;
                    break;
                case 3:
                    profileSpecificKey = Keys.D3;
                    break;
                default:
                    profileSpecificKey = Keys.D1;
                    break;
            }

            // Create a new Profile object
            Profile newProfile = new Profile
            {
                ProfileName = profileName,
                MonitorInfoList = selectedMonitors,
                Opacity = opacity,
                Shortcut = new Keys[] { Keys.ControlKey, Keys.Shift, profileSpecificKey } // Default shortcut
            };

            // Save the new profile
            _dataStorage.SaveProfile(newProfile);
            ReloadProfiles();


            // Update the profile list
            ProfileBox profileBox = GetProfileBoxByIndex(profileIndex);

            profileBox.SetVisibles(true);

            profileBox.SetDataStorage(_dataStorage);
            profileBox.SetDimContent(opacity);
            profileBox.SetDimScreen(this);
            profileBox.SetProfile(newProfile);

            // Retrieve the selected indices from listBoxMonitors
            List<int> selectedIndicesList = new List<int>();
            foreach (int selectedIndex in listBoxMonitors.SelectedIndices)
            {
                selectedIndicesList.Add(selectedIndex);
            }

            // Pass the selected indices list to SetScreensContent method of profileBox
            profileBox.SetScreensContent(selectedIndicesList);

            // Update the profile count and button state
            CheckAndUpdateSetProfileButton();

            PopulateProfileShortcuts();
        }

        private void labelHelp_MouseHover(object sender, EventArgs e)
        {
            _toolTip.SetToolTip(labelHelp, "- Click on display name to rename." +
                "\n- After saving a profile, click on the shortcut to save a new combination." +
                "\n- The profile shortcut resets the dim if the profile dim is already applied.");
        }

        private void labelInfo_Click(object sender, EventArgs e)
        {
            _aboutBox.Close();
            _aboutBox = new AboutForm();

            int x = Location.X + (Width - _aboutBox.Width) / 2;
            int y = Location.Y + (Height - _aboutBox.Height) / 2;
            _aboutBox.Location = new Point(x, y);

            _aboutBox.TopMost = true;
            _aboutBox.Show();
        }
        #endregion

        #region Helper Methods
        private ProfileBox GetProfileBoxByIndex(int index)
        {
            switch (index)
            {
                case 1:
                    return profileBox1;
                case 2:
                    return profileBox2;
                case 3:
                    return profileBox3;
                default:
                    return null;
            }
        }

        private void CheckAndUpdateApplyDimButton()
        {
            if (listBoxMonitors.SelectedIndices.Count > 0 && trackBarOpacity.Value != 0)
            {
                buttonApplyDim.Enabled = true;
            }
            else
            {
                buttonApplyDim.Enabled = false;
            }
        }

        public void CheckAndUpdateSetProfileButton()
        {
            if (_profileList.Count >= 3)
            {
                buttonSetProfile.Enabled = false;
            }
            else
            {
                if (listBoxMonitors.SelectedIndices.Count > 0 && trackBarOpacity.Value != 0)
                {
                    buttonSetProfile.Enabled = true;
                }
                else
                {
                    buttonSetProfile.Enabled = false;
                }
            }
        }

        private void ExitApplication()
        {
            SaveWindowPosition();
            DisposeOverlayWindows();
            _notifyIcon?.Dispose();
            UnhookWindowsHookEx(_hookID);
            Application.Exit();
        }

        [GeneratedRegex(@"\d+")]
        private static partial Regex MyRegex();
        #endregion

    }
}
