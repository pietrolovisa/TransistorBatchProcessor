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

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool Editable { get; set; }

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
            comboBoxType.InitCombobox(ComboBoxType_SelectedIndexChanged);
        }

        private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ResetEntityFromInput()
        {
            _entityInfo.Entity.Name = textBoxName.Text;
            BatchType batchType = comboBoxType.SelectedItem as BatchType;
            _entityInfo.Entity.BatchTypeId = batchType.Id;
        }

        protected void PopulateInputFromEntity()
        {
            textBoxName.Text = _entityInfo.Entity.Name;
            comboBoxType.SelectedValue = _entityInfo.Entity.BatchTypeId;
        }

        public void ResetBatchTypes(List<BatchType> batchTypes)
        {
            comboBoxType.DataSource = batchTypes;
        }

        public bool Validate(out string message)
        {
            if (comboBoxType.SelectedIndex == -1)
            {
                message = $"{nameof(Batch.Type)} is invalid.";
                return false;
            }
            else if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                message = $"{nameof(Batch.Name)} is invalid.";
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
        }

        public void LoadTypes(List<BatchType> batchTypes)
        {
            comboBoxType.Items.Clear();
            foreach (BatchType batchType in batchTypes)
            {
                comboBoxType.Items.Add(batchType);
            }
        }
    }
}
