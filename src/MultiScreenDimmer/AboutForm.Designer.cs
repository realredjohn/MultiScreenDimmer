namespace MultiScreenDimmer
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            textBoxAbout = new RichTextBox();
            textBoxLicense = new RichTextBox();
            labelAbout = new Label();
            labelLicense = new Label();
            SuspendLayout();
            // 
            // textBoxAbout
            // 
            textBoxAbout.BackColor = Color.White;
            textBoxAbout.Font = new Font("Segoe UI", 8F);
            textBoxAbout.Location = new Point(12, 38);
            textBoxAbout.Name = "textBoxAbout";
            textBoxAbout.ReadOnly = true;
            textBoxAbout.Size = new Size(703, 197);
            textBoxAbout.TabIndex = 0;
            textBoxAbout.Text = resources.GetString("textBoxAbout.Text");
            // 
            // textBoxLicense
            // 
            textBoxLicense.BackColor = Color.White;
            textBoxLicense.Font = new Font("Segoe UI", 8F);
            textBoxLicense.Location = new Point(12, 273);
            textBoxLicense.Name = "textBoxLicense";
            textBoxLicense.ReadOnly = true;
            textBoxLicense.Size = new Size(703, 252);
            textBoxLicense.TabIndex = 0;
            textBoxLicense.Text = resources.GetString("textBoxLicense.Text");
            // 
            // labelAbout
            // 
            labelAbout.AutoSize = true;
            labelAbout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelAbout.Location = new Point(12, 12);
            labelAbout.Name = "labelAbout";
            labelAbout.Size = new Size(172, 23);
            labelAbout.TabIndex = 1;
            labelAbout.Text = "MultiScreenDimmer";
            // 
            // labelLicense
            // 
            labelLicense.AutoSize = true;
            labelLicense.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelLicense.Location = new Point(12, 247);
            labelLicense.Name = "labelLicense";
            labelLicense.Size = new Size(67, 23);
            labelLicense.TabIndex = 1;
            labelLicense.Text = "License";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(728, 534);
            StartPosition = FormStartPosition.Manual;
            Controls.Add(labelLicense);
            Controls.Add(labelAbout);
            Controls.Add(textBoxLicense);
            Controls.Add(textBoxAbout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            Text = "About MultiScreenDimmer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox textBoxAbout;
        private RichTextBox textBoxLicense;
        private Label labelAbout;
        private Label labelLicense;
    }
}