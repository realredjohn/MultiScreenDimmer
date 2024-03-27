using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DimScreen
{
    public partial class ProfileBox : UserControl
    {
        private string dimIcon = "💡";
        private string screenIcon = "🖥️";

        private DataStorage? _dataStorage;
        private MultiScreenDimmer? _dimScreen;
        private Profile? _profile;

        public ProfileBox()
        {
            InitializeComponent();
        }


        #region UI Methods

        public void SetHeaderText(string text)
        {
            labelHeader.Text = text;
        }

        public void SetDimContent(int dimLevel)
        {
            labelDimIcon.Text = $"{dimIcon} {dimLevel}%";
        }

        public void SetScreensContent(List<int> screenIndexes)
        {
            string screensContent = string.Join(" ", screenIndexes.Select(index => $"[{index + 1}]"));
            labelScreensIcon.Text = $"[{screenIcon}] {screensContent}";
        }

        public void SetDataStorage(DataStorage? storage)
        {
            _dataStorage = storage;
        }

        public void SetDimScreen(MultiScreenDimmer dimScreen)
        {
            _dimScreen = dimScreen;
        }

        public void SetProfile(Profile profile)
        {
            _profile = profile;

            SetHeaderText(profile.ProfileName);
            SetShortcutLabel(profile.Shortcut);
        }

        public void SetVisibles(bool visible)
        {
            labelShortcut.Visible = visible;
            buttonDelete.Visible = visible;
            buttonApplyProfileDim.Visible = visible;
            labelShortcutInfo.Visible = visible;
        }

        private void ResetContent()
        {
            labelHeader.Text = "";
            labelDimIcon.Text = "";
            labelScreensIcon.Text = "";

            SetDataStorage(null);
            SetVisibles(false);
        }

        #endregion

        #region Event Handlers

        private void textBoxShortcut_Click(object sender, EventArgs e)
        {
            using (ShortcutPopupForm popupForm = new ShortcutPopupForm())
            {
                int x = _dimScreen.Location.X + (_dimScreen.Width - popupForm.Width) / 2;
                int y = _dimScreen.Location.Y + (_dimScreen.Height - popupForm.Height) / 2;
                popupForm.Location = new Point(x, y);

                popupForm.ShortcutSet += PopupForm_ShortcutSet;
                popupForm.TopMost = true;

                _dimScreen.SetIsShortcutPopupOpen(true);

                popupForm.ShowDialog();

                _dimScreen.SetIsShortcutPopupOpen(false);
            }
        }

        private void PopupForm_ShortcutSet(object sender, ShortcutEventArgs e)
        {
            string shortcutString = e.Shortcut;
            labelShortcut.Text = shortcutString;

            Keys[] keysArray = ConvertToKeysArray(shortcutString);

            _dataStorage.EditProfileShortcut(_profile.ProfileName, keysArray);

            _dimScreen.ReloadProfiles();
            _dimScreen.PopulateProfileShortcuts();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _dataStorage.DeleteProfile(_profile.ProfileName);
            _dimScreen.CheckAndUpdateSetProfileButton();
            ResetContent();
            _dimScreen.ReloadProfiles();
            _dimScreen.PopulateProfileShortcuts();
        }

        private void buttonApplyProfileDim_Click(object sender, EventArgs e)
        {
            _dimScreen.Dim(_profile);
        }

        #endregion

        #region Helper Methods

        private void SetShortcutLabel(Keys[] keys)
        {
            string shortcutString = "";

            for (int i = 0; i < keys.Length; i++)
            {
                if (i == 0)
                {
                    shortcutString += GetKeyLabel(keys[i]);
                }
                else
                {
                    shortcutString += " + " + GetKeyLabel(keys[i]);
                }
            }

            labelShortcut.Text = shortcutString;
        }

        private Keys[] ConvertToKeysArray(string shortcut)
        {
            string[] keysString = shortcut.Split(new string[] { " + " }, StringSplitOptions.RemoveEmptyEntries);
            Keys[] keysArray = new Keys[keysString.Length];

            for (int i = 0; i < keysString.Length; i++)
            {
                keysArray[i] = ConvertToKeys(keysString[i]);
            }

            return keysArray;
        }

        private Keys ConvertToKeys(string keyString)
        {
            switch (keyString.ToLower())
            {
                case "ctrl":
                    return Keys.ControlKey;
                case "shift":
                    return Keys.ShiftKey;
                case "alt":
                    return Keys.Menu;
                default:
                    if (int.TryParse(keyString, out int number))
                    {
                        if (number >= 0 && number <= 9)
                        {
                            return (Keys)((int)Keys.D0 + number);
                        }
                    }
                    else if (keyString.Length == 1 && char.IsLetter(keyString[0]))
                    {
                        return (Keys)char.ToUpper(keyString[0]);
                    }

                    return Keys.None;
            }
        }

        private string GetKeyLabel(Keys key)
        {
            switch (key)
            {
                case Keys.ControlKey:
                    return "Ctrl";
                case Keys.Menu:
                    return "Alt";
                case Keys.ShiftKey:
                    return "Shift";
                case Keys.D0:
                    return "0";
                case Keys.D1:
                    return "1";
                case Keys.D2:
                    return "2";
                case Keys.D3:
                    return "3";
                case Keys.D4:
                    return "4";
                case Keys.D5:
                    return "5";
                case Keys.D6:
                    return "6";
                case Keys.D7:
                    return "7";
                case Keys.D8:
                    return "8";
                case Keys.D9:
                    return "9";
                default:
                    return key.ToString();
            }
        }

        #endregion
    }
}
