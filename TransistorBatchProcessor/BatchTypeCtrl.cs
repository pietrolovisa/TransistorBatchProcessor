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

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool Editable { get; set; }

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
        }

        protected void ResetEntityFromInput()
        {
            _entityInfo.Entity.Name = textBoxName.Text;
            _entityInfo.Entity.Description = textBoxDescription.Text;
        }

        public bool Validate(out string message)
        {
            if (string.IsNullOrWhiteSpace(textBoxDescription.Text))
            {
                message = $"{nameof(BatchType.Description)} is invalid.";
                return false;
            }
            else if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                message = $"{nameof(BatchType.Name)} is invalid.";
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
            textBoxName.Text = isNew ? string.Empty : _entityInfo.Entity.Name;
            textBoxDescription.Text = isNew ? string.Empty : _entityInfo.Entity.Description;
        }
    }
}
