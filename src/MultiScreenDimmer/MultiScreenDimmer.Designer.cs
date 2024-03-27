namespace DimScreen
{
    partial class MultiScreenDimmer
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            buttonSetDim = new Button();
            buttonShowNumbers = new Button();
            trackBarOpacity = new TrackBar();
            textBoxOpacityValue = new TextBox();
            buttonResetDim = new Button();
            listBoxMonitors = new ListBox();
            labelPerc = new Label();
            buttonSetProfile = new Button();
            labelHelp = new Label();
            profileBox1 = new ProfileBox();
            profileBox2 = new ProfileBox();
            profileBox3 = new ProfileBox();
            panelVerticalLine1 = new Panel();
            labelInfo = new Label();
            notifyIcon1 = new NotifyIcon(components);
            checkStartup = new CheckBox();
            checkHideOnClose = new CheckBox();
            buttonToggleProfilesSection = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBarOpacity).BeginInit();
            SuspendLayout();
            // 
            // buttonSetDim
            // 
            buttonSetDim.Enabled = false;
            buttonSetDim.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSetDim.Location = new Point(360, 178);
            buttonSetDim.Name = "buttonSetDim";
            buttonSetDim.Size = new Size(303, 56);
            buttonSetDim.TabIndex = 13;
            buttonSetDim.Text = "Apply Dim";
            buttonSetDim.UseVisualStyleBackColor = true;
            buttonSetDim.Click += buttonSetDim_Click;
            // 
            // buttonShowNumbers
            // 
            buttonShowNumbers.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonShowNumbers.Location = new Point(360, 28);
            buttonShowNumbers.Name = "buttonShowNumbers";
            buttonShowNumbers.Size = new Size(303, 56);
            buttonShowNumbers.TabIndex = 10;
            buttonShowNumbers.Text = "Identify Displays";
            buttonShowNumbers.UseVisualStyleBackColor = true;
            buttonShowNumbers.Click += buttonShowNumbers_Click;
            // 
            // trackBarOpacity
            // 
            trackBarOpacity.LargeChange = 10;
            trackBarOpacity.Location = new Point(360, 104);
            trackBarOpacity.Maximum = 100;
            trackBarOpacity.Name = "trackBarOpacity";
            trackBarOpacity.Size = new Size(240, 56);
            trackBarOpacity.SmallChange = 5;
            trackBarOpacity.TabIndex = 11;
            trackBarOpacity.TickFrequency = 5;
            trackBarOpacity.TickStyle = TickStyle.Both;
            trackBarOpacity.Scroll += trackBarOpacity_Scroll;
            trackBarOpacity.ValueChanged += trackBarOpacity_ValueChanged;
            trackBarOpacity.MouseHover += trackBarOpacity_MouseHover;
            // 
            // textBoxOpacityValue
            // 
            textBoxOpacityValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            textBoxOpacityValue.Location = new Point(597, 113);
            textBoxOpacityValue.Name = "textBoxOpacityValue";
            textBoxOpacityValue.Size = new Size(44, 30);
            textBoxOpacityValue.TabIndex = 12;
            textBoxOpacityValue.Text = "0";
            textBoxOpacityValue.TextChanged += TextBoxOpacityValue_TextChanged;
            // 
            // buttonResetDim
            // 
            buttonResetDim.Enabled = false;
            buttonResetDim.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonResetDim.Location = new Point(360, 251);
            buttonResetDim.Name = "buttonResetDim";
            buttonResetDim.Size = new Size(303, 56);
            buttonResetDim.TabIndex = 14;
            buttonResetDim.Text = "Reset All";
            buttonResetDim.UseVisualStyleBackColor = true;
            buttonResetDim.Click += buttonResetDim_Click;
            // 
            // listBoxMonitors
            // 
            listBoxMonitors.Font = new Font("Segoe UI", 11F);
            listBoxMonitors.FormattingEnabled = true;
            listBoxMonitors.ItemHeight = 25;
            listBoxMonitors.Location = new Point(29, 28);
            listBoxMonitors.Name = "listBoxMonitors";
            listBoxMonitors.SelectionMode = SelectionMode.MultiSimple;
            listBoxMonitors.Size = new Size(313, 279);
            listBoxMonitors.TabIndex = 9;
            listBoxMonitors.SelectedIndexChanged += listBoxMonitors_SelectedIndexChanged;
            listBoxMonitors.MouseDoubleClick += listBoxMonitors_MouseDoubleClick;
            // 
            // labelPerc
            // 
            labelPerc.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelPerc.Location = new Point(641, 113);
            labelPerc.Name = "labelPerc";
            labelPerc.Size = new Size(22, 30);
            labelPerc.TabIndex = 100;
            labelPerc.Text = "%";
            // 
            // buttonSetProfile
            // 
            buttonSetProfile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSetProfile.Location = new Point(29, 324);
            buttonSetProfile.Name = "buttonSetProfile";
            buttonSetProfile.Size = new Size(562, 56);
            buttonSetProfile.TabIndex = 15;
            buttonSetProfile.Text = "Save Profile";
            buttonSetProfile.UseVisualStyleBackColor = true;
            buttonSetProfile.Click += buttonSetProfile_Click;
            // 
            // labelHelp
            // 
            labelHelp.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelHelp.Location = new Point(597, 454);
            labelHelp.Name = "labelHelp";
            labelHelp.Size = new Size(23, 37);
            labelHelp.TabIndex = 7;
            labelHelp.Text = "?";
            labelHelp.MouseHover += labelHelp_MouseHover;
            // 
            // profileBox1
            // 
            profileBox1.BackColor = Color.FromArgb(247, 247, 247);
            profileBox1.BorderStyle = BorderStyle.FixedSingle;
            profileBox1.Location = new Point(725, 28);
            profileBox1.Name = "profileBox1";
            profileBox1.Size = new Size(514, 142);
            profileBox1.TabIndex = 136;
            // 
            // profileBox2
            // 
            profileBox2.BackColor = Color.FromArgb(247, 247, 247);
            profileBox2.BorderStyle = BorderStyle.FixedSingle;
            profileBox2.Location = new Point(725, 187);
            profileBox2.Name = "profileBox2";
            profileBox2.Size = new Size(514, 142);
            profileBox2.TabIndex = 17;
            // 
            // profileBox3
            // 
            profileBox3.BackColor = Color.FromArgb(247, 247, 247);
            profileBox3.BorderStyle = BorderStyle.FixedSingle;
            profileBox3.Location = new Point(725, 349);
            profileBox3.Name = "profileBox3";
            profileBox3.Size = new Size(514, 142);
            profileBox3.TabIndex = 18;
            // 
            // panelVerticalLine1
            // 
            panelVerticalLine1.BackColor = Color.Black;
            panelVerticalLine1.Location = new Point(692, 28);
            panelVerticalLine1.Name = "panelVerticalLine1";
            panelVerticalLine1.Size = new Size(1, 464);
            panelVerticalLine1.TabIndex = 100;
            // 
            // labelInfo
            // 
            labelInfo.Cursor = Cursors.Hand;
            labelInfo.Font = new Font("Segoe UI", 16F);
            labelInfo.Location = new Point(626, 454);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(37, 37);
            labelInfo.TabIndex = 7;
            labelInfo.Text = "🛈";
            labelInfo.Click += labelInfo_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // checkStartup
            // 
            checkStartup.AutoSize = true;
            checkStartup.Location = new Point(29, 464);
            checkStartup.Name = "checkStartup";
            checkStartup.Size = new Size(159, 24);
            checkStartup.TabIndex = 137;
            checkStartup.Text = "Start with Windows";
            checkStartup.UseVisualStyleBackColor = true;
            checkStartup.CheckedChanged += checkStartup_CheckedChanged;
            // 
            // checkHideOnClose
            // 
            checkHideOnClose.AutoSize = true;
            checkHideOnClose.Location = new Point(222, 464);
            checkHideOnClose.Name = "checkHideOnClose";
            checkHideOnClose.Size = new Size(247, 24);
            checkHideOnClose.TabIndex = 137;
            checkHideOnClose.Text = "Minimize to system tray on close";
            checkHideOnClose.UseVisualStyleBackColor = true;
            checkHideOnClose.CheckedChanged += checkHideOnClose_CheckedChanged;
            // 
            // buttonToggleProfilesSection
            // 
            buttonToggleProfilesSection.Font = new Font("Segoe UI", 14F);
            buttonToggleProfilesSection.Location = new Point(606, 324);
            buttonToggleProfilesSection.Name = "buttonToggleProfilesSection";
            buttonToggleProfilesSection.Size = new Size(57, 56);
            buttonToggleProfilesSection.TabIndex = 15;
            buttonToggleProfilesSection.Text = "ᐅ";
            buttonToggleProfilesSection.UseVisualStyleBackColor = true;
            buttonToggleProfilesSection.Click += buttonToggleProfilesSection_Click;
            buttonToggleProfilesSection.MouseHover += buttonToggleProfilesSection_MouseHover;
            // 
            // DimScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(692, 516);
            Controls.Add(checkHideOnClose);
            Controls.Add(checkStartup);
            Controls.Add(profileBox3);
            Controls.Add(profileBox2);
            Controls.Add(profileBox1);
            Controls.Add(panelVerticalLine1);
            Controls.Add(buttonToggleProfilesSection);
            Controls.Add(buttonSetProfile);
            Controls.Add(labelPerc);
            Controls.Add(labelInfo);
            Controls.Add(labelHelp);
            Controls.Add(listBoxMonitors);
            Controls.Add(buttonResetDim);
            Controls.Add(textBoxOpacityValue);
            Controls.Add(trackBarOpacity);
            Controls.Add(buttonShowNumbers);
            Controls.Add(buttonSetDim);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "DimScreen";
            Text = "MultiScreenDimmer";
            Icon = global::MultiScreenDimmer.Properties.Resources.msd_icon_ico_3;
            ((System.ComponentModel.ISupportInitialize)trackBarOpacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Size originalSize = new Size(692, 516);
        private Size sizeWithProfiles = new Size(1264, 516);

        private Button buttonSetDim;
        private Button buttonShowNumbers;
        private TrackBar trackBarOpacity;
        private TextBox textBoxOpacityValue;
        private Button buttonResetDim;
        private ListBox listBoxMonitors;
        private Label labelPerc;
        private Button buttonSetProfile;
        private Label labelHelp;
        private ProfileBox profileBox1;
        private ProfileBox profileBox2;
        private ProfileBox profileBox3;
        private Panel panelVerticalLine1;
        private Label labelInfo;
        private NotifyIcon notifyIcon1;
        private CheckBox checkStartup;
        private CheckBox checkHideOnClose;
        private Button buttonToggleProfilesSection;
    }
}
