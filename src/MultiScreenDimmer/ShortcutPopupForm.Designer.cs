namespace DimScreen
{
    partial class ShortcutPopupForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            instructionLabel = new Label();
            shortcutLabel = new Label();
            okButton = new Button();
            infoLabel = new Label();
            SuspendLayout();
            // 
            // instructionLabel
            // 
            instructionLabel.AutoSize = true;
            instructionLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            instructionLabel.Location = new Point(12, 18);
            instructionLabel.Name = "instructionLabel";
            instructionLabel.Size = new Size(218, 23);
            instructionLabel.TabIndex = 0;
            instructionLabel.Text = "Press a key combination...";
            // 
            // shortcutLabel
            // 
            shortcutLabel.BackColor = SystemColors.ControlLightLight;
            shortcutLabel.BorderStyle = BorderStyle.FixedSingle;
            shortcutLabel.Location = new Point(12, 142);
            shortcutLabel.Name = "shortcutLabel";
            shortcutLabel.Size = new Size(289, 34);
            shortcutLabel.TabIndex = 1;
            shortcutLabel.TextAlign = ContentAlignment.MiddleCenter;
            shortcutLabel.Click += ShortcutLabel_Click;
            // 
            // okButton
            // 
            okButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            okButton.Location = new Point(321, 142);
            okButton.Name = "okButton";
            okButton.Size = new Size(65, 34);
            okButton.TabIndex = 2;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += OkButton_Click;
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Font = new Font("Segoe UI", 9F);
            infoLabel.Location = new Point(12, 48);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(234, 60);
            infoLabel.TabIndex = 0;
            infoLabel.Text = "* Click on the text field to reset\n* Max. 3 keys\n* Allowed keys: Ctrl, Shift, 0-9, A-Z";
            // 
            // ShortcutPopupForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(398, 201);
            Controls.Add(okButton);
            Controls.Add(shortcutLabel);
            Controls.Add(infoLabel);
            Controls.Add(instructionLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = global::MultiScreenDimmer.Properties.Resources.msd_icon_ico_3;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ShortcutPopupForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Set Shortcut";
            KeyDown += ShortcutPopupForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label instructionLabel;
        private Label shortcutLabel;
        private Button okButton;
        private Label infoLabel;
    }
}