namespace DimScreen
{
    partial class ProfileBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelHeader = new Label();
            labelDimIcon = new Label();
            labelScreensIcon = new Label();
            labelShortcut = new Label();
            buttonDelete = new Button();
            buttonApplyProfileDim = new Button();
            labelShortcutInfo = new Label();
            SuspendLayout();
            // 
            // labelHeader
            // 
            labelHeader.BackColor = Color.FromArgb(224, 224, 224);
            labelHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelHeader.Location = new Point(-1, -1);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(516, 34);
            labelHeader.TabIndex = 0;
            labelHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelDimIcon
            // 
            labelDimIcon.Font = new Font("Segoe UI", 12F);
            labelDimIcon.Location = new Point(18, 48);
            labelDimIcon.Name = "labelDimIcon";
            labelDimIcon.Size = new Size(243, 35);
            labelDimIcon.TabIndex = 1;
            labelDimIcon.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelScreensIcon
            // 
            labelScreensIcon.Font = new Font("Segoe UI", 12F);
            labelScreensIcon.Location = new Point(12, 92);
            labelScreensIcon.Name = "labelScreensIcon";
            labelScreensIcon.Size = new Size(249, 35);
            labelScreensIcon.TabIndex = 2;
            labelScreensIcon.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelShortcut
            // 
            labelShortcut.BackColor = SystemColors.ControlLightLight;
            labelShortcut.BorderStyle = BorderStyle.FixedSingle;
            labelShortcut.Cursor = Cursors.Hand;
            labelShortcut.Font = new Font("Segoe UI", 10F);
            labelShortcut.Location = new Point(339, 48);
            labelShortcut.Name = "labelShortcut";
            labelShortcut.Size = new Size(163, 32);
            labelShortcut.TabIndex = 3;
            labelShortcut.TextAlign = ContentAlignment.MiddleCenter;
            labelShortcut.Visible = false;
            labelShortcut.Click += textBoxShortcut_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.ForeColor = Color.Gray;
            buttonDelete.Location = new Point(483, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(28, 28);
            buttonDelete.TabIndex = 4;
            buttonDelete.Text = "❌";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Visible = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonApplyProfileDim
            // 
            buttonApplyProfileDim.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonApplyProfileDim.Location = new Point(339, 93);
            buttonApplyProfileDim.Name = "buttonApplyProfileDim";
            buttonApplyProfileDim.Size = new Size(163, 32);
            buttonApplyProfileDim.TabIndex = 5;
            buttonApplyProfileDim.Text = "Apply";
            buttonApplyProfileDim.UseVisualStyleBackColor = true;
            buttonApplyProfileDim.Visible = false;
            buttonApplyProfileDim.Click += buttonApplyProfileDim_Click;
            // 
            // labelShortcutInfo
            // 
            labelShortcutInfo.Font = new Font("Segoe UI", 8F);
            labelShortcutInfo.Location = new Point(265, 49);
            labelShortcutInfo.Name = "labelShortcutInfo";
            labelShortcutInfo.Size = new Size(68, 35);
            labelShortcutInfo.TabIndex = 0;
            labelShortcutInfo.Text = "Shortcut";
            labelShortcutInfo.TextAlign = ContentAlignment.MiddleLeft;
            labelShortcutInfo.Visible = false;
            // 
            // ProfileBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(buttonApplyProfileDim);
            Controls.Add(buttonDelete);
            Controls.Add(labelShortcut);
            Controls.Add(labelDimIcon);
            Controls.Add(labelScreensIcon);
            Controls.Add(labelShortcutInfo);
            Controls.Add(labelHeader);
            Name = "ProfileBox";
            Size = new Size(514, 142);
            ResumeLayout(false);
        }

        #endregion

        private Label labelHeader;
        private Label labelDimIcon;
        private Label labelScreensIcon;
        private Label labelShortcut;
        private Button buttonDelete;
        private Button buttonApplyProfileDim;
        private Label labelShortcutInfo;
    }
}
