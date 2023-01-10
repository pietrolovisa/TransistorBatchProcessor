using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransisterBatch.EntityFramework.Domain;
using TransisterBatch.EntityFramework.Repository;

using TransisterBatchCore;
using TransistorBatchProcessor.Extensions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TransistorBatchProcessor
{
    public partial class Processor : UserControl, IManagementTool
    {
        public event EventHandler<NotificationEventArgs> OnNotify;

        public string DisplayName => "Transistor Processor";

        private readonly IBatchTypeRepository _batchTypeRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly ITransistorRepository _transistorRepository;

        private bool SupressEvents { get; set; } = false;
        private Batch ActiveBatch { get; set; }
        private TransistorGroupDiscovery ActiveDiscovery { get; set; }

        public Processor(
            IBatchRepository batchRepository,
            IBatchTypeRepository batchTypeRepository,
            ITransistorRepository transistorRepository)
            : this()
        {
            _batchRepository = batchRepository;
            _batchTypeRepository = batchTypeRepository;
            _transistorRepository = transistorRepository;
        }

        public Processor()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            comboBoxBatches.InitCombobox(ComboBoxBatches_SelectedIndexChanged, "Description");
            listView1.InitListView(new ListViewColumnSorter(), ListViewSelectedIndexChanged,
                new List<Tuple<string, int, ColumnHeaderType>>
                {
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.Id), 0, ColumnHeaderType.numeric) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.Idx), 140, ColumnHeaderType.numeric) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.HEF), 140, ColumnHeaderType.numeric) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.Beta), 140, ColumnHeaderType.numeric) }
                });
            listView2.InitListView(new ListViewColumnSorter(), ListViewSelectedIndexChanged,
                new List<Tuple<string, int, ColumnHeaderType>>
                {
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.Id), 0, ColumnHeaderType.numeric) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.Idx), 140, ColumnHeaderType.numeric) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.HEF), 140, ColumnHeaderType.numeric) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.Beta), 140, ColumnHeaderType.numeric) }
                });
        }

        private void ListViewSelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void LockToBatch(Batch batch)
        {
            comboBoxBatches.SelectedValue = batch.Id;
            comboBoxBatches.Enabled = false;
        }

        private void ComboBoxBatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SupressEvents) return;

            Batch selectedItem = comboBoxBatches.SelectedItem as Batch;
            ActiveBatch = _batchRepository.FindByKey(selectedItem.Id, new BatchQueryFilter
            {
                IncludeBatchType = true
            }).GetAwaiter().GetResult();
            LoadTransistors();
            ResetMatches();
        }

        public void HandleEvent(NotificationEventArgs args)
        {
            if (args.Event == EventType.BatchItemChanged)
            {
                ResetBatches();
            }
        }

        public void InitializeView()
        {
            commandAndControl1.ApplyOverride(Command.Remove, "Remove matches");
            commandAndControl1.ApplyOverride(Command.Restore, "Reset");
            commandAndControl1.ApplyOverride(Command.Add, "Show matches");
            commandAndControl1.OnCommand += CommandAndControl1_OnCommand;
            ResetBatches();
        }

        private void CommandAndControl1_OnCommand(object sender, CommandArgs e)
        {
            bool _ = e.Command switch
            {
                Command.Remove => HandleRemove(),
                Command.Restore => HandleRestore(),
                Command.Add => HandleProcess(),
                _ => throw new InvalidOperationException($"Command Type [{e.Command}] has no handler.")
            };
        }

        private bool HandleRemove()
        {
            if (ActiveDiscovery != null)
            {
                _transistorRepository.UpdateGroups(ActiveDiscovery.Matches).GetAwaiter().GetResult();
                _transistorRepository.ClearTracker();
                ResetView();
            }
            return true;
        }

        private bool HandleRestore()
        {
            ResetView();
            return true;
        }

        private bool HandleProcess()
        {
            IBatchProcessor batchProcessor = new BatchProcessor();
            TransistorGroupLoadArgs args = new TransistorGroupLoadArgs
            {
                BetaTolerance = (double)numericUpDownBetaTolerance.Value,
                HefTolerance = (int)numericUpDownHefTolerance.Value
            };

            List<Transistor> transistors = _transistorRepository.FindByBatchIdAndUnmatched(ActiveBatch.Id).GetAwaiter().GetResult();
            ActionResult<TransistorGroupDiscovery> result = batchProcessor.GenerateTransisterManifest(transistors, args);
            listView2.ClearAll();
            if (result.Success)
            {
                int index = 1;
                foreach (TransistorGroup group in result.Data.Matches)
                {
                    ListViewGroup listViewGroup = new ListViewGroup($"Group {index} ({group.Count})", HorizontalAlignment.Left);
                    listView2.Groups.Add(listViewGroup);
                    group.ForEach(t => listView2.AddItemToView(t, listViewGroup));
                    index++;
                }

                ListViewGroup outlierListViewGroup = new ListViewGroup($"Unmatched ({result.Data.Outliers.Count})", HorizontalAlignment.Left);
                listView2.Groups.Add(outlierListViewGroup);
                foreach (TransistorGroup group in result.Data.Outliers)
                {
                    group.ForEach(t => listView2.AddItemToView(t, outlierListViewGroup));
                }

                listView2.ResetSortOrder();
                ResetMatches(result.Data);

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"Processed [{result.Data.Discovery.Count}] item(s).");
                stringBuilder.AppendLine($"{Environment.NewLine}Found [{result.Data.Matches.Count}] match(es) containing [{result.Data.Matches.Sum(m => m.Count)}] transistor(s)");
                stringBuilder.AppendLine($"{Environment.NewLine}Found [{result.Data.Outliers.Count}] outlier(s).");
                labelShowMatchDetails.Text = stringBuilder.ToString();
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK);
            }
            return true;
        }

        private void ResetMatches(TransistorGroupDiscovery activeDiscovery = null)
        {
            ActiveDiscovery = activeDiscovery;
            Command commands = Command.Restore | Command.Add;
            if (ActiveDiscovery != null && ActiveDiscovery.Matches.Count > 0)
            {
                commands |= Command.Remove;
            }
            commandAndControl1.ToggleCommands(commands);
        }

        private void ResetBatches()
        {
            List<Batch> batches = _batchRepository.FindAll(new BatchQueryFilter
            {
                IncludeBatchType = true
            }).GetAwaiter().GetResult();
            comboBoxBatches.DataSource = batches;
            if (ActiveBatch != null)
            {
                comboBoxBatches.SelectedValue = ActiveBatch.Id;
            }
        }

        private void LoadTransistors()
        {
            listView1.ClearAll();
            List<Transistor> transistors = _transistorRepository.FindByBatchIdAndUnmatched(ActiveBatch.Id).GetAwaiter().GetResult();
            listView1.LoadItems<Transistor>(transistors);
            listView1.ResetSortOrder();
            labelListDetails.Text = $"{transistors.Count} transistor(s)";
        }

        private void ResetView()
        {
            labelShowMatchDetails.Text = string.Empty;
            listView2.ClearAll();
            LoadTransistors();
            ResetMatches();
        }
    }
}
