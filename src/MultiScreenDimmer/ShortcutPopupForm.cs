using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DimScreen
{
    public partial class ShortcutPopupForm : Form
    {
        private readonly HashSet<Keys> pressedKeys = new HashSet<Keys>();
        private readonly StringBuilder shortcutStringBuilder = new StringBuilder();

        private string? shortcutString;

        public event EventHandler<ShortcutEventArgs>? ShortcutSet;

        public ShortcutPopupForm()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += ShortcutPopupForm_KeyDown;
        }

        private void ShortcutPopupForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (!pressedKeys.Contains(e.KeyCode) && pressedKeys.Count < 3)
            {
                if (IsAllowedKey(e.KeyCode))
                {
                    pressedKeys.Add(e.KeyCode);
                    UpdateShortcutLabel();
                }

                e.Handled = true;
            }
        }

        private bool IsAllowedKey(Keys key)
        {
            return IsModifierKey(key) || (key >= Keys.D0 && key <= Keys.Z);
        }

        private void UpdateShortcutLabel()
        {
            shortcutStringBuilder.Clear();

            foreach (var key in pressedKeys)
            {
                shortcutStringBuilder.Append(GetKeyLabel(key)).Append(" + ");
            }

            shortcutString = shortcutStringBuilder.ToString().TrimEnd('+', ' ');
            shortcutLabel.Text = shortcutString;
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
                default:
                    return key >= Keys.D0 && key <= Keys.D9 ? key.ToString()[1].ToString() : key.ToString();
            }
        }

        private bool IsModifierKey(Keys key)
        {
            return key == Keys.ControlKey || key == Keys.ShiftKey;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (shortcutString != null)
            {
                ShortcutSet?.Invoke(this, new ShortcutEventArgs(shortcutString));
            }

            Close();
        }


        private void ShortcutLabel_Click(object sender, EventArgs e)
        {
            pressedKeys.Clear();
            UpdateShortcutLabel();
            Focus();
        }
    }


    public class ShortcutEventArgs : EventArgs
    {
        public string Shortcut { get; }

        public ShortcutEventArgs(string shortcut)
        {
            Shortcut = shortcut;
        }
    }
}
