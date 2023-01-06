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
using TransistorBatchProcessor.Extensions;

namespace TransistorBatchProcessor
{
    public partial class ComboEditor : UserControl, IEditorControl
    {
        public string Caption { get; set; }
        public bool IsReadonly { get; set; } = false;

        public ComboEditor()
        {
            InitializeComponent();
            comboBox.InitCombobox(ComboBoxType_SelectedIndexChanged);
        }

        private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void InitializeControls()
        {
            label.Text = Caption;
            comboBox.Enabled = !IsReadonly;
        }

        public void ResetBatchTypes<T>(List<T> datasource)
        {
            comboBox.DataSource = datasource;
        }

        public void Toggle(bool enabled)
        {
            if (IsReadonly) return;
            comboBox.Enabled = !enabled;
        }

        public T GetSelectedItem<T>()
        {
            return (T)comboBox.SelectedItem;
        }

        public void SetSelected(long valueMember)
        {
            comboBox.SelectedValue = valueMember;
        }

        public int SelectedIndex => comboBox.SelectedIndex;
    }
}
