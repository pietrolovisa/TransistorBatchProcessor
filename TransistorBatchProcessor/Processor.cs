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
            //LoadMatched();
            ResetMatches();
        }

        public void HandleEvent(NotificationEventArgs args)
        {
            if (args.Event == EventType.BatchAdded || args.Event == EventType.BatchRemoved)
            {
                ResetBatches();
            }
        }

        public void InitializeView()
        {
            ResetBatches();
        }

        private void ResetMatches(TransistorGroupDiscovery activeDiscovery = null)
        {
            ActiveDiscovery = activeDiscovery;
            buttonRemoveMatches.Enabled = ActiveDiscovery != null && ActiveDiscovery.Matches.Count > 0;
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

        //private void LoadMatched()
        //{
        //    listView2.ClearAll();
        //    List<Transistor> transistors = _transistorRepository.FindByBatchIdAndMatched(ActiveBatch.Id).GetAwaiter().GetResult();
        //    List<TransistorGroup> batches = transistors.GroupBy(t => t.GroupId)
        //        .Select(grp => new TransistorGroup(grp.ToList()))
        //        .OrderByDescending(grp => grp.Count)
        //        .ToList();
        //    int index = 1;
        //    foreach (TransistorGroup group in batches)
        //    {
        //        ListViewGroup listViewGroup = new ListViewGroup($"Group {index} ({group.Count})", HorizontalAlignment.Left);
        //        listView2.Groups.Add(listViewGroup);
        //        group.ForEach(t => listView2.AddItemToView(t, listViewGroup));
        //        index++;
        //    }
        //}

        private void ButtonProcessBatch_Click(object sender, EventArgs e)
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
                stringBuilder.AppendLine($"Found [{result.Data.ItemCount}] item(s).");
                stringBuilder.AppendLine($"Found [{result.Data.Matches.Count}] match(es).");
                stringBuilder.AppendLine($"Found [{result.Data.Outliers.Count}] outlier(s).");
                labelShowMatchDetails.Text = stringBuilder.ToString();
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void ButtonRemoveMatches_Click(object sender, EventArgs e)
        {
            if (ActiveDiscovery != null)
            {
                _transistorRepository.UpdateGroups(ActiveDiscovery.Matches).GetAwaiter().GetResult();
                LoadTransistors();
                //LoadMatched();
                ResetMatches();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            labelShowMatchDetails.Text = string.Empty;
            listView2.ClearAll();
            LoadTransistors();
            ResetMatches();
        }
    }
}
