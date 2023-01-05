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
    public partial class CommandAndControl : UserControl
    {
        private Panel ButtonContainer = new Panel
        {
            Dock = DockStyle.Fill,
        };
        private CommandButton AddButton = new CommandButton
        {
            Dock = DockStyle.Top,
            Command = Command.Add
        };
        private CommandButton UpdateButton = new CommandButton
        {
            Dock = DockStyle.Top,
            Command = Command.Update
        };
        private CommandButton RemoveButton = new CommandButton
        {
            Dock = DockStyle.Top,
            Command = Command.Remove
        };
        private CommandButton RestoreButton = new CommandButton
        {
            Dock = DockStyle.Top,
            Command = Command.Restore
        };
        private CommandButton RestoreAllButton = new CommandButton
        {
            Dock = DockStyle.Top,
            Command = Command.RestoreAll
        };
        private CommandButton ProcessButton = new CommandButton
        {
            Dock = DockStyle.Top,
            Command = Command.Process
        };

        public event EventHandler<CommandArgs> OnCommand;

        public CommandAndControl()
        {
            InitializeComponent();
            LoadCommandAndControl();
        }

        private void LoadCommandAndControl()
        {
            ButtonContainer.Controls.Add(ProcessButton);
            ButtonContainer.Controls.Add(RestoreAllButton);
            ButtonContainer.Controls.Add(RestoreButton);
            ButtonContainer.Controls.Add(RemoveButton);
            ButtonContainer.Controls.Add(UpdateButton);
            ButtonContainer.Controls.Add(AddButton);
            Controls.Add(ButtonContainer);
            foreach (CommandButton command in ButtonContainer.Controls.OfType<CommandButton>())
            {
                command.Height = 42;
                command.InitializeControls();
                command.OnCommand += Command_OnCommand;
            }
        }

        private void Command_OnCommand(object sender, CommandArgs e)
        {
            OnCommand?.Invoke(sender, e);
        }

        public void ToggleCommands(Command commands)
        {
            foreach (CommandButton command in ButtonContainer.Controls.OfType<CommandButton>())
            {
                bool enabled = commands.HasFlag(command.Command);
                command.Visible = enabled;
            }
        }
    }
}
