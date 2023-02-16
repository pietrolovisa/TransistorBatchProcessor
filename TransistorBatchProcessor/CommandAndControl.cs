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
            Command = Command.Add,
            TabIndex = 0
        };
        private CommandButton UpdateButton = new CommandButton
        {
            Dock = DockStyle.Top,
            Command = Command.Update,
            TabIndex = 1
        };
        private CommandButton RemoveButton = new CommandButton
        {
            Dock = DockStyle.Top,
            Command = Command.Remove,
            TabIndex = 2
        };
        private CommandButton RestoreButton = new CommandButton
        {
            Dock = DockStyle.Top,
            Command = Command.Restore,
            TabIndex = 3
        };
        private CommandButton RestoreAllButton = new CommandButton
        {
            Dock = DockStyle.Top,
            Command = Command.RestoreAll,
            TabIndex = 4
        };
        private CommandButton ProcessButton = new CommandButton
        {
            Dock = DockStyle.Top,
            Command = Command.Process,
            TabIndex = 5
        };

        public event EventHandler<CommandArgs> OnCommand;

        public Dictionary<Command, string> Overrides = new Dictionary<Command, string>
        {
            {Command.RestoreAll, "Restore All" }
        };

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
                command.Height = 36;
                command.InitializeControls();
                command.OnCommand += Command_OnCommand;
            }
        }

        public void ApplyOverride(Command command, string text)
        {
            Overrides[command] = text;
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
                if(enabled && Overrides.ContainsKey(command.Command))
                {
                    command.ApplyOverride(Overrides[command.Command]);
                }
                command.Visible = enabled;
            }
        }
    }
}
