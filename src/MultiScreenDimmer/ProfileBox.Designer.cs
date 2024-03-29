using System.Drawing;
using System.Windows.Forms;

namespace DimScreen
{
    partial class ProfileBox : UserControl
    {
        private TableLayoutPanel tableLayoutPanelProfileBox;

        private Label labelHeader;
        private Label labelDimIcon;
        private Label labelScreensIcon;
        private Label labelShortcut;
        private Button buttonDelete;
        private Button buttonApplyProfileDim;
        private Label labelShortcutInfo;


        private void InitializeComponent()
        {
            tableLayoutPanelProfileBox = new TableLayoutPanel();

            labelHeader = new Label();
            labelDimIcon = new Label();
            labelScreensIcon = new Label();
            labelShortcut = new Label();
            buttonDelete = new Button();
            buttonApplyProfileDim = new Button();
            labelShortcutInfo = new Label();

            // TableLayoutPanel settings
            tableLayoutPanelProfileBox.SuspendLayout();
            tableLayoutPanelProfileBox.Dock = DockStyle.Fill;
            tableLayoutPanelProfileBox.ColumnCount = 2;
            tableLayoutPanelProfileBox.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanelProfileBox.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanelProfileBox.RowCount = 4;
            tableLayoutPanelProfileBox.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            tableLayoutPanelProfileBox.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));
            tableLayoutPanelProfileBox.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            tableLayoutPanelProfileBox.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));

            // labelHeader settings
            labelHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelHeader.TextAlign = ContentAlignment.MiddleLeft;
            labelHeader.Text = "";
            labelHeader.Dock = DockStyle.Fill;

            // labelDimIcon settings
            labelDimIcon.TextAlign = ContentAlignment.TopLeft;
            labelDimIcon.Text = "";
            labelDimIcon.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            // labelScreensIcon settings
            labelScreensIcon.TextAlign = ContentAlignment.TopLeft;
            labelScreensIcon.Text = "";
            labelScreensIcon.Dock = DockStyle.Fill;

            // labelShortcut settings
            labelShortcut.BackColor = SystemColors.ControlLightLight;
            labelShortcut.BorderStyle = BorderStyle.FixedSingle;
            labelShortcut.Cursor = Cursors.Hand;
            labelShortcut.TextAlign = ContentAlignment.MiddleCenter;
            labelShortcut.Visible = false;
            labelShortcut.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            labelShortcut.Text = "";
            labelShortcut.Margin = new Padding(0, 0, 4, 4);

            labelShortcut.Click += textBoxShortcut_Click;

            // buttonDelete settings
            buttonDelete.Font = new Font("Segoe UI", 6F);
            buttonDelete.ForeColor = Color.Gray;
            buttonDelete.Text = "❌";
            buttonDelete.Width = buttonDelete.Height;
            buttonDelete.Anchor = AnchorStyles.Right;
            buttonDelete.Visible = false;

            buttonDelete.Click += buttonDelete_Click;

            // buttonApplyProfileDim settings
            buttonApplyProfileDim.Font = new Font("Segoe UI", 7F);
            buttonApplyProfileDim.Text = "Apply";
            buttonApplyProfileDim.Dock = DockStyle.Fill;
            buttonApplyProfileDim.Visible = false;
            buttonApplyProfileDim.Margin = new Padding(0, 0, 4, 4);

            buttonApplyProfileDim.Click += buttonApplyProfileDim_Click;

            // labelShortcutInfo settings
            //labelShortcutInfo.TextAlign = ContentAlignment.MiddleLeft;
            //labelShortcutInfo.Text = "Shortcut";
            //labelShortcutInfo.TextAlign = ContentAlignment.MiddleRight;
            //labelShortcutInfo.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            //labelShortcutInfo.Visible = false;

            // Add controls to tableLayoutPanelProfileBox
            tableLayoutPanelProfileBox.Controls.Add(labelHeader, 0, 0);
            tableLayoutPanelProfileBox.Controls.Add(buttonDelete, 1, 0);
            tableLayoutPanelProfileBox.Controls.Add(labelDimIcon, 0, 2);
            tableLayoutPanelProfileBox.Controls.Add(labelScreensIcon, 0, 3);
            tableLayoutPanelProfileBox.Controls.Add(labelShortcut, 1, 2);
            tableLayoutPanelProfileBox.Controls.Add(buttonApplyProfileDim, 1, 3);

            // Set UserControl properties
            Controls.Add(tableLayoutPanelProfileBox);
            Name = "ProfileBox";
            AutoSize = true;
            tableLayoutPanelProfileBox.ResumeLayout(false);
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
