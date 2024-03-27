using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DimScreen
{
    public partial class MonitorNumberForm : Form
    {
        private const int FormWidth = 235;
        private const int FormHeight = 340;
        private const int FontSize = 144;
        private const string DefaultBackgroundColor = "#1e2121";

        private Label? label;

        public MonitorNumberForm(string monitorNumber)
        {
            InitializeComponents(monitorNumber);
            TopMost = true;
        }

        private void InitializeComponents(string monitorNumber)
        {
            FormBorderStyle = FormBorderStyle.None;
            BackColor = ColorTranslator.FromHtml(DefaultBackgroundColor);
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            Size = new Size(FormWidth, FormHeight);

            int monitorNumberInt = ExtractMonitorNumber(monitorNumber);
            if (monitorNumberInt == -1)
            {
                return;
            }

            AddLabel(monitorNumberInt);
        }

        private static int ExtractMonitorNumber(string monitorNumber)
        {
            string numberString = Regex.Match(monitorNumber, @"\d+").Value;
            if (!int.TryParse(numberString, out int monitorNumberInt))
            {
                MessageBox.Show("Failed to parse monitor number.");
                return -1;
            }
            return monitorNumberInt;
        }

        private void AddLabel(int monitorNumber)
        {
            label = new Label();
            label.Text = monitorNumber.ToString();
            label.AutoSize = false;
            label.Size = ClientSize;
            label.Font = new Font(label.Font.FontFamily, FontSize, label.Font.Style);

            int x = (ClientSize.Width - label.Width) / 2;
            int y = (ClientSize.Height - label.Height) / 2;
            label.Location = new Point(x, y);

            label.ForeColor = Color.White;
            Controls.Add(label);
        }
    }
}
