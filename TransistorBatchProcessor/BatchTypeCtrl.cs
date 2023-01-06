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

namespace TransistorBatchProcessor
{
    public partial class BatchTypeCtrl : UserControl
    {
        protected EntityWrapper<BatchType> _entityInfo = default;

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
        private TextEditor NameTextEditor = new TextEditor
        {
            Dock = DockStyle.Top,
            Caption = "Name",
        };
        private TextEditor DescTextEditor = new TextEditor
        {
            Dock = DockStyle.Top,
            Caption = "Description"
        };

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool SupressEvents { get; set; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EntityWrapper<BatchType> EntityInfo
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

        public BatchTypeCtrl()
        {
            InitializeComponent();
            LoadCommandAndControl();
        }

        private void LoadCommandAndControl()
        {
            ControlContainer.Controls.Add(DescTextEditor);
            ControlContainer.Controls.Add(NameTextEditor);
            ControlContainer.Controls.Add(Details);
            Controls.Add(ControlContainer);
            foreach (IEditorControl control in ControlContainer.Controls.OfType<IEditorControl>())
            {
                control.Height = 34;
                control.InitializeControls();
            }
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

        public void Toggle(bool enabled)
        {
            foreach (TextEditor command in ControlContainer.Controls.OfType<TextEditor>())
            {
                command.Toggle(enabled);
            }
        }

        protected void ResetEntityFromInput()
        {
            _entityInfo.Entity.Name = NameTextEditor.Text;
            _entityInfo.Entity.Description = DescTextEditor.Text;
        }

        public bool Validate(out string message)
        {
            if (string.IsNullOrWhiteSpace(NameTextEditor.Text))
            {
                message = $"{nameof(BatchType.Name)} is invalid.";
                return false;
            }
            else if (string.IsNullOrWhiteSpace(DescTextEditor.Text))
            {
                message = $"{nameof(BatchType.Description)} is invalid.";
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
            bool isNew = _entityInfo.State == EditState.New;
            NameTextEditor.Text = isNew ? string.Empty : _entityInfo.Entity.Name;
            DescTextEditor.Text = isNew ? string.Empty : _entityInfo.Entity.Description;
        }
    }
}
