using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransisterBatch.EntityFramework.Domain;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TransistorBatchProcessor
{
    public partial class TransistorCtrl : UserControl
    {
        protected EntityWrapper<Transistor> _entityInfo = default;

        private Panel ControlContainer = new Panel
        {
            Dock = DockStyle.Fill,
        };

        private Label Details = new Label
        {
            Dock = DockStyle.Top,
            AutoSize = false,
            Height = 32
        };
        private TextEditor IdxTextEditor = new TextEditor
        {
            Dock = DockStyle.Top,
            Caption = "Id",
            IsReadonly = true
        };
        private TextEditor HFETextEditor = new TextEditor
        {
            Dock = DockStyle.Top,
            Caption = "HFE"
        };
        private TextEditor BetaTextEditor = new TextEditor
        {
            Dock = DockStyle.Top,
            Caption = "Beta"
        };

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool SupressEvents { get; set; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EntityWrapper<Transistor> EntityInfo
        {
            get
            {
                ResetEntityFromInput();
                return _entityInfo;
            }
            set
            {
                try
                {
                    _entityInfo = value;
                    SupressEvents = true;
                    PopulateInputFromEntity();
                }
                finally
                {
                    SupressEvents = false;
                }
            }
        }

        public TransistorCtrl()
        {
            InitializeComponent();
            LoadCommandAndControl();
        }

        public override string Text
        {
            get
            {
                return Details.Text;
            }
            set
            {
                Details.Text = value;
            }
        }

        private void LoadCommandAndControl()
        {
            ControlContainer.Controls.Add(BetaTextEditor);
            ControlContainer.Controls.Add(HFETextEditor);
            ControlContainer.Controls.Add(IdxTextEditor);
            ControlContainer.Controls.Add(Details);
            Controls.Add(ControlContainer);
            foreach (TextEditor command in ControlContainer.Controls.OfType<TextEditor>())
            {
                command.Height = 34;
                command.InitializeControls();
            }
        }

        public void Toggle(bool enabled)
        {
            foreach (TextEditor command in ControlContainer.Controls.OfType<TextEditor>())
            {
                command.Toggle(enabled);
            }
        }

        protected void ResetEntityFromInput()
        {
            _entityInfo.Entity.Idx = long.Parse(IdxTextEditor.Text);
            _entityInfo.Entity.HEF = double.Parse(HFETextEditor.Text);
            _entityInfo.Entity.Beta = double.Parse(BetaTextEditor.Text);
        }

        public bool Validate(out string message)
        {
            if(!double.TryParse(HFETextEditor.Text, out double _))
            {
                message = $"{nameof(Transistor.HEF)} is invalid.";
                return false;
            }
            else if (!double.TryParse(BetaTextEditor.Text, out double _))
            {
                message = $"{nameof(Transistor.Beta)} is invalid.";
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
        }

        protected void PopulateInputFromEntity()
        {
            if (_entityInfo == null)
            {
                IdxTextEditor.Text = string.Empty;
                HFETextEditor.Text = string.Empty;
                BetaTextEditor.Text = string.Empty;
            }
            else
            {
                bool isNew = _entityInfo.State == EditState.New;
                IdxTextEditor.Text = _entityInfo.Entity.Idx.ToString();
                HFETextEditor.Text = isNew ? string.Empty : _entityInfo.Entity.HEF.ToString();
                BetaTextEditor.Text = isNew ? string.Empty : _entityInfo.Entity.Beta.ToString();
            }
        }
    }
}
