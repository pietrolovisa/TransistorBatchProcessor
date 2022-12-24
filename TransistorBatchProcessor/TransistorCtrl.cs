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
    public partial class TransistorCtrl : UserControl //Base<Transistor>
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
                _entityInfo.Entity = CreateEntityFromInput();
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
            UpdateEnabled(true);
        }

        protected Transistor CreateEntityFromInput()
        {
            return new Transistor
            {
                Idx = long.Parse(textBoxIdx.Text),
                HEF = double.Parse(textBoxHEF.Text),
                Beta = double.Parse(textBoxBeta.Text)
            };
        }

        public bool Validate(out string message)
        {
            message = string.Empty;
            return true;
        }

        public void UpdateEnabled(bool enabled)
        {
            Editable = enabled;
            textBoxIdx.ReadOnly = true;
            textBoxHEF.ReadOnly = !Editable;
            textBoxBeta.ReadOnly = !Editable;
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
