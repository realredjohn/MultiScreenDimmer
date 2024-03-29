namespace DimScreen
{
    partial class MultiScreenDimmer
    {
        private TableLayoutPanel tableLayoutPanelMain;

        private TableLayoutPanel innerTableTrackbar;
        private TableLayoutPanel innerTableExtra;
        private TableLayoutPanel innerTableProfiles;
        
        private ListBox listBoxMonitors;
        private Button buttonIdentifyDisplays;
        private Button buttonApplyDim;
        private TrackBar trackBarOpacity;
        private TextBox textBoxDimValue;
        private Label labelDimPerc;
        private Button buttonResetDim;
        private Button buttonSetProfile;
        private CheckBox checkBoxStartup;
        private CheckBox checkBoxMinimize;
        private Label labelHelp;
        private Label labelInfo;
        private Panel panelVerticalLine1;
        private ProfileBox profileBox1;
        private ProfileBox profileBox2;
        private ProfileBox profileBox3;
        private NotifyIcon notifyIcon1;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            tableLayoutPanelMain = new TableLayoutPanel();

            innerTableTrackbar = new TableLayoutPanel();
            innerTableExtra = new TableLayoutPanel();
            innerTableProfiles = new TableLayoutPanel();
            
            listBoxMonitors = new ListBox();
            buttonIdentifyDisplays = new Button();
            buttonApplyDim = new Button();
            trackBarOpacity = new TrackBar();
            textBoxDimValue = new TextBox();
            labelDimPerc = new Label();
            buttonResetDim = new Button();
            buttonSetProfile = new Button();
            checkBoxStartup = new CheckBox();
            checkBoxMinimize = new CheckBox();
            labelHelp = new Label();
            labelInfo = new Label();
            panelVerticalLine1 = new Panel();
            profileBox1 = new ProfileBox();
            profileBox2 = new ProfileBox();
            profileBox3 = new ProfileBox();
            notifyIcon1 = new NotifyIcon(components);
            
            ((System.ComponentModel.ISupportInitialize)trackBarOpacity).BeginInit();
            SuspendLayout();


            //
            // TableLayoutPanel settings
            tableLayoutPanelMain.SuspendLayout();
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.ColumnCount = 4;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            tableLayoutPanelMain.RowCount = 6;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 2F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 2F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 2F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 2F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 2F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 3F));

            // listBoxMonitors settings
            listBoxMonitors.FormattingEnabled = true;
            listBoxMonitors.ItemHeight = 20; // ????
            listBoxMonitors.SelectionMode = SelectionMode.MultiSimple;
            listBoxMonitors.Dock = DockStyle.Fill;
            listBoxMonitors.Margin = new Padding(10, 5, 10, 5);
            listBoxMonitors.TabIndex = 0; // add all

            listBoxMonitors.SelectedIndexChanged += listBoxMonitors_SelectedIndexChanged;
            listBoxMonitors.MouseDoubleClick += listBoxMonitors_MouseDoubleClick;

            // buttonShowNumbers settings
            buttonIdentifyDisplays.Text = "Identify Displays";
            buttonIdentifyDisplays.UseVisualStyleBackColor = true;
            buttonIdentifyDisplays.Dock = DockStyle.Fill;
            buttonIdentifyDisplays.Margin = new Padding(10, 5, 10, 5);

            buttonIdentifyDisplays.Click += buttonIdentifyDisplays_Click;
                        
            // trackBarOpacity settings
            trackBarOpacity.LargeChange = 10;
            trackBarOpacity.SmallChange = 5;
            trackBarOpacity.TickFrequency = 3;
            trackBarOpacity.Maximum = 100;
            trackBarOpacity.Dock = DockStyle.Fill;

            trackBarOpacity.Scroll += trackBarOpacity_Scroll;
            trackBarOpacity.ValueChanged += trackBarOpacity_ValueChanged;
            trackBarOpacity.MouseHover += trackBarOpacity_MouseHover;

            // textBoxOpacityValue settings
            textBoxDimValue.Dock = DockStyle.Fill;
            textBoxDimValue.Anchor = AnchorStyles.Top;
            textBoxDimValue.Margin = new Padding(2);
            textBoxDimValue.Text = "0";

            textBoxDimValue.TextChanged += TextBoxOpacityValue_TextChanged;

            // labelPerc settings
            labelDimPerc.Dock = DockStyle.Fill;
            labelDimPerc.Anchor = AnchorStyles.Top;
            labelDimPerc.TextAlign = ContentAlignment.MiddleLeft;
            labelDimPerc.Margin = new Padding(2);
            labelDimPerc.Text = "%";


            //
            // innerTableTrackbar settings
            innerTableTrackbar.Dock = DockStyle.Fill;
            innerTableTrackbar.ColumnCount = 3;
            innerTableTrackbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6f));
            innerTableTrackbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2f));
            innerTableTrackbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1f));

            innerTableTrackbar.Controls.Add(trackBarOpacity, 0, 0);
            innerTableTrackbar.Controls.Add(textBoxDimValue, 1, 0);
            innerTableTrackbar.Controls.Add(labelDimPerc, 2, 0);

            // buttonSetDim settings
            buttonApplyDim.Enabled = false;
            buttonApplyDim.Text = "Apply Dim";
            buttonApplyDim.UseVisualStyleBackColor = true;
            buttonApplyDim.Dock = DockStyle.Fill;
            buttonApplyDim.Margin = new Padding(10, 5, 10, 5);

            buttonApplyDim.Click += buttonApplyDim_Click;

            // buttonResetDim settings
            buttonResetDim.Enabled = false;
            buttonResetDim.Text = "Reset All";
            buttonResetDim.UseVisualStyleBackColor = true;
            buttonResetDim.Dock = DockStyle.Fill;
            buttonResetDim.Margin = new Padding(10, 5, 10, 5);

            buttonResetDim.Click += buttonResetDim_Click;

            // buttonSetProfile settings
            buttonSetProfile.Text = "Save Profile";
            buttonSetProfile.UseVisualStyleBackColor = true;
            buttonSetProfile.Dock = DockStyle.Fill;
            buttonSetProfile.Margin = new Padding(10, 5, 10, 5);

            buttonSetProfile.Click += buttonSetProfile_Click;


            //
            // innerTableExtra settings
            innerTableExtra.Dock = DockStyle.Fill;
            innerTableExtra.ColumnCount = 3;
            innerTableExtra.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8f));
            innerTableExtra.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1f));
            innerTableExtra.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1f));
            innerTableExtra.RowCount = 2;
            innerTableExtra.RowStyles.Add(new RowStyle(SizeType.Percent, 1f));
            innerTableExtra.RowStyles.Add(new RowStyle(SizeType.Percent, 1f));

            innerTableExtra.Controls.Add(checkBoxStartup, 0, 0);
            innerTableExtra.Controls.Add(checkBoxMinimize, 0, 1);
            innerTableExtra.Controls.Add(labelHelp, 1, 1);
            innerTableExtra.Controls.Add(labelInfo, 2, 1);

            // checkStartup settings
            checkBoxStartup.AutoSize = true;
            checkBoxStartup.Text = "Start with Windows";
            checkBoxStartup.UseVisualStyleBackColor = true;
            checkBoxStartup.Margin = new Padding(10, 0, 0, 0);

            checkBoxStartup.CheckedChanged += checkBoxStartup_CheckedChanged;

            // checkHideOnClose settings
            checkBoxMinimize.AutoSize = true;
            checkBoxMinimize.Text = "Minimize to system tray on close";
            checkBoxMinimize.UseVisualStyleBackColor = true;
            checkBoxMinimize.Margin = new Padding(10, 0, 0, 0);

            checkBoxMinimize.CheckedChanged += checkBoxMinimize_CheckedChanged;

            // labelHelp settings
            labelHelp.TabIndex = 7;
            labelHelp.Text = "?";
            labelHelp.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelHelp.TextAlign = ContentAlignment.MiddleCenter;

            labelHelp.MouseHover += labelHelp_MouseHover;

            // labelInfo settings
            labelInfo.Cursor = Cursors.Hand;
            labelInfo.Text = "🛈";
            labelInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelInfo.TextAlign = ContentAlignment.MiddleCenter;

            labelInfo.Click += labelInfo_Click;

            // panelVerticalLine1 settings
            panelVerticalLine1.BackColor = Color.LightGray;
            panelVerticalLine1.Dock = DockStyle.Fill;
            panelVerticalLine1.Margin = new Padding(9, 5, 9, 5);


            //
            // innerTableProfiles settings
            innerTableProfiles.Dock = DockStyle.Fill;
            innerTableProfiles.RowCount = 3;
            innerTableProfiles.RowStyles.Add(new RowStyle(SizeType.Percent, 1f));
            innerTableProfiles.RowStyles.Add(new RowStyle(SizeType.Percent, 1f));
            innerTableProfiles.RowStyles.Add(new RowStyle(SizeType.Percent, 1f));

            innerTableProfiles.Controls.Add(profileBox1, 0, 0);
            innerTableProfiles.Controls.Add(profileBox2, 0, 1);
            innerTableProfiles.Controls.Add(profileBox3, 0, 2);

            // profileBox1 settings
            profileBox1.Dock = DockStyle.Fill;
            profileBox1.BackColor = Color.FromArgb(247, 247, 247);
            profileBox1.BorderStyle = BorderStyle.FixedSingle;
            profileBox1.Margin = new Padding(10, 5, 10, 5);

            // profileBox2 setting
            profileBox2.Dock = DockStyle.Fill;
            profileBox2.BackColor = Color.FromArgb(247, 247, 247);
            profileBox2.BorderStyle = BorderStyle.FixedSingle;
            profileBox2.Margin = new Padding(10, 5, 10, 5);

            // profileBox3 settings
            profileBox3.Dock = DockStyle.Fill;
            profileBox3.BackColor = Color.FromArgb(247, 247, 247);
            profileBox3.BorderStyle = BorderStyle.FixedSingle;
            profileBox3.Margin = new Padding(10, 5, 10, 5);

            // notifyIcon1 settings
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;


            // Add controls to tableLayoutPanelProfileBox
            tableLayoutPanelMain.Controls.Add(listBoxMonitors, 0, 0);
            tableLayoutPanelMain.SetRowSpan(listBoxMonitors, 4);

            tableLayoutPanelMain.Controls.Add(buttonIdentifyDisplays, 1, 0);

            tableLayoutPanelMain.Controls.Add(innerTableTrackbar, 1, 1);

            tableLayoutPanelMain.Controls.Add(buttonApplyDim, 1, 2);

            tableLayoutPanelMain.Controls.Add(buttonResetDim, 1, 3);

            tableLayoutPanelMain.Controls.Add(buttonSetProfile, 0, 4);
            tableLayoutPanelMain.SetColumnSpan(buttonSetProfile, 2);

            tableLayoutPanelMain.Controls.Add(innerTableExtra, 0, 5);
            tableLayoutPanelMain.SetColumnSpan(innerTableExtra, 2);

            tableLayoutPanelMain.Controls.Add(panelVerticalLine1, 2, 0);
            tableLayoutPanelMain.SetRowSpan(panelVerticalLine1, 6);

            tableLayoutPanelMain.Controls.Add(innerTableProfiles, 3, 0);
            tableLayoutPanelMain.SetRowSpan(innerTableProfiles, 6);


            
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(740, 300);

            Controls.Add(tableLayoutPanelMain);
            tableLayoutPanelMain.ResumeLayout(false);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = global::MultiScreenDimmer.Properties.Resources.msd_icon_ico_3;

            KeyPreview = true;
            MaximizeBox = false;

            Name = "MultiScreenDimmer";
            Text = "MultiScreenDimmer";

            ((System.ComponentModel.ISupportInitialize)trackBarOpacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        



        #region Designer default
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
