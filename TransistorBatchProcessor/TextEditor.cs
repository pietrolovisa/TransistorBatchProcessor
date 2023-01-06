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
    public partial class TextEditor : UserControl
    {
        public string Caption { get; set; }
        public bool IsReadonly { get; set; } = false;

        public TextEditor()
        {
            InitializeComponent();
        }

        public void InitializeControls()
        {
            label.Text = Caption;
            textBox.ReadOnly = IsReadonly;
        }

        public void Toggle(bool enabled)
        {
            if (IsReadonly) return;
            textBox.ReadOnly = !enabled;
        }

        public override string Text 
        { 
            get
            {
                return textBox.Text;
            }
            set
            {
                textBox.Text = value;
            }
        }
    }
}
