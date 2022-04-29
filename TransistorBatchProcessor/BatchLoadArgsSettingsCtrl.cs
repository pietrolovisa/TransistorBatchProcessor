using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TransisterBatchCore;

namespace TransistorBatchProcessor
{
    public partial class BatchLoadArgsSettingsCtrl : UserControl
    {
        public BatchLoadArgsSettingsCtrl()
        {
            InitializeComponent();
        }

        public void ResetSource(List<string> data)
        {
            foreach (string name in data)
            {
                comboBoxSourceWorkSheet.Items.Add(name);
            }
            if (comboBoxSourceWorkSheet.Items.Count > 0) comboBoxSourceWorkSheet.SelectedIndex = 0;
        }

        public TransistorBatchLoadArgs BatchLoadArgs
        {
            get
            {
                return new TransistorBatchLoadArgs
                {
                    Name = comboBoxSourceWorkSheet.SelectedItem?.ToString(),
                    StartRow = (int)numericUpDownStartRow.Value,
                    KeyColumn = (int)numericUpDownKeyColumn.Value,
                    HefColumn = (int)numericUpDownHefColumn.Value,
                    BetaColumn = (int)numericUpDownBetaColumn.Value,
                    BetaTolerance = (double)numericUpDownBetaTolerance.Value,
                    HefTolerance = (int)numericUpDownHefTolerance.Value
                };
            }
            set 
            {
                numericUpDownStartRow.Value = value.StartRow;
                numericUpDownKeyColumn.Value = value.KeyColumn;
                numericUpDownHefColumn.Value = value.HefColumn;
                numericUpDownBetaColumn.Value = value.BetaColumn;
                numericUpDownBetaTolerance.Value = (decimal)value.BetaTolerance;
                numericUpDownHefTolerance.Value = value.HefTolerance;
            }
        }

        public void SetState(bool enabled)
        {
            comboBoxSourceWorkSheet.Enabled = enabled;
            numericUpDownStartRow.Enabled = enabled;
            numericUpDownKeyColumn.Enabled = enabled;
            numericUpDownHefColumn.Enabled = enabled;
            numericUpDownBetaColumn.Enabled = enabled;
            numericUpDownBetaTolerance.Enabled = enabled;
            numericUpDownHefTolerance.Enabled = enabled;
        }
    }
}
