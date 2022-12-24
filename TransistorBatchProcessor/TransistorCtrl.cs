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

namespace TransistorBatchProcessor
{
    public partial class TransistorCtrl : UserControl
    {
        protected EntityWrapper<Transistor> _entityInfo = default;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool Editable { get; set; }

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
            textBoxIdx.ReadOnly = true;
        }

        protected void ResetEntityFromInput()
        {
            _entityInfo.Entity.Idx = long.Parse(textBoxIdx.Text);
            _entityInfo.Entity.HEF = double.Parse(textBoxHEF.Text);
            _entityInfo.Entity.Beta = double.Parse(textBoxBeta.Text);
        }

        public bool Validate(out string message)
        {
            if(!double.TryParse(textBoxHEF.Text, out double _))
            {
                message = $"{nameof(Transistor.HEF)} is invalid.";
                return false;
            }
            else if (!double.TryParse(textBoxBeta.Text, out double _))
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
            bool isNew = _entityInfo.State == EditState.New;
            textBoxIdx.Text = _entityInfo.Entity.Idx.ToString();
            textBoxHEF.Text = isNew ? string.Empty : _entityInfo.Entity.HEF.ToString();
            textBoxBeta.Text = isNew ? string.Empty : _entityInfo.Entity.Beta.ToString();
        }
    }
}
