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
using TransisterBatch.EntityFramework.Repository;
using TransistorBatchProcessor.Extensions;

namespace TransistorBatchProcessor
{
    public partial class BatchCtrl : UserControl
    {
        protected EntityWrapper<Batch> _entityInfo = default;

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
        private ComboEditor TypeComboEditor = new ComboEditor
        {
            Dock = DockStyle.Top,
            Caption = "Type"
        };

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool SupressEvents { get; set; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EntityWrapper<Batch> EntityInfo
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

        public BatchCtrl()
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
            ControlContainer.Controls.Add(TypeComboEditor);
            ControlContainer.Controls.Add(NameTextEditor);
            ControlContainer.Controls.Add(Details);
            Controls.Add(ControlContainer);
            foreach (TextEditor command in ControlContainer.Controls.OfType<TextEditor>())
            {
                command.Height = 34;
                command.InitializeControls();
            }
        }

        protected void ResetEntityFromInput()
        {
            _entityInfo.Entity.Name = NameTextEditor.Text;
            BatchType batchType = TypeComboEditor.GetSelectedItem<BatchType>();
            _entityInfo.Entity.BatchTypeId = batchType.Id;
        }

        protected void PopulateInputFromEntity()
        {
            NameTextEditor.Text = _entityInfo.Entity.Name;
            TypeComboEditor.SetSelected(_entityInfo.Entity.BatchTypeId);
        }

        public void ResetBatchTypes(List<BatchType> batchTypes)
        {
            TypeComboEditor.ResetBatchTypes(batchTypes);
        }

        public bool Validate(out string message)
        {
            if (string.IsNullOrWhiteSpace(NameTextEditor.Text))
            {
                message = $"{nameof(Batch.Name)} is invalid.";
                return false;
            }
            else if (TypeComboEditor.SelectedIndex == -1)
            {
                message = $"{nameof(Batch.Type)} is invalid.";
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
        }
    }
}
