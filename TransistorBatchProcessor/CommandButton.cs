using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransistorBatchProcessor
{
    public enum Command
    {
        None = 0,
        Add = 1,
        Update = 2,
        Remove = 4,
        Restore = 8,
        RestoreAll = 16,
        Process = 32,
    }

    delegate void RaiseCommandDelegate(NotificationEventArgs args);

    public class CommandArgs : EventArgs
    {
        public Command Command { get; set; } = Command.None;

        public CommandArgs()
        {
        }
    }

    public partial class CommandButton : UserControl
    {
        public event EventHandler<CommandArgs> OnCommand;

        public Command Command { get; set; } = Command.None;

        public CommandButton()
        {
            InitializeComponent();
        }

        public void InitializeControls()
        {
            ApplyOverride(Command.ToString());
        }

        public void ApplyOverride(string text)
        {
            button.Text = text;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            OnCommand?.Invoke(this, new CommandArgs() { Command = Command });
        }
    }
}
