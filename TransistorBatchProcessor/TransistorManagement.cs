using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TransisterBatch.EntityFramework.Domain;
using TransisterBatch.EntityFramework.Repository;
using TransistorBatchProcessor.Extensions;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TransistorBatchProcessor
{
    public partial class TransistorManagement : UserControl, IManagementTool
    {
        public string DisplayName => "Transistor Management";

        public event EventHandler<NotificationEventArgs> OnNotify;

        private readonly IBatchTypeRepository _batchTypeRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly ITransistorRepository _transistorRepository;

        private bool SupressEvents { get; set; } = false;
        private Batch ActiveBatch { get; set; }

        public TransistorManagement(
            IBatchRepository batchRepository, 
            IBatchTypeRepository batchTypeRepository,
            ITransistorRepository transistorRepository)
            : this()
        {
            _batchRepository = batchRepository;
            _batchTypeRepository = batchTypeRepository;
            _transistorRepository = transistorRepository;
        }

        public TransistorManagement()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            comboBoxBatches.InitCombobox(ComboBoxBatches_SelectedIndexChanged, "Description");
            comboBoxState.InitCombobox(ComboBoxState_SelectedIndexChanged);
            listView1.InitListView(new ListViewColumnSorter(), ListViewSelectedIndexChanged,
                new List<Tuple<string, int, ColumnHeaderType>>
                {
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.Id), 0, ColumnHeaderType.numeric) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.Idx), 140, ColumnHeaderType.numeric) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.HEF), 140, ColumnHeaderType.numeric) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Transistor.Beta), 140, ColumnHeaderType.numeric) }
                });
        }

        public void InitializeView()
        {
            //labelListDetails.Text = string.Empty;
            ResetBatches();
            ResetState();
            ReloadTransistors();
            commandAndControl1.ApplyOverride(Command.Process, "Find matches ...");
            commandAndControl1.OnCommand += CommandAndControl1_OnCommand;
            ListViewSelectedIndexChanged(null, null);
        }

        private void CommandAndControl1_OnCommand(object sender, CommandArgs e)
        {
            bool _ = e.Command switch
            {
                Command.Add => HandleAdd(),
                Command.Update => HandleUpdate(),
                Command.Remove => HandleRemove(),
                Command.Restore => HandleRestore(),
                Command.RestoreAll => HandleRestoreAll(),
                Command.Process => HandleProcess(),
                _ => throw new InvalidOperationException($"Command Type [{e.Command}] has no handler.")
            };
        }

        private bool HandleAdd()
        {
            if (transistorCtrl1.Validate(out string message))
            {
                Transistor transistor = transistorCtrl1.EntityInfo.Entity;
                transistor.BatchId = ActiveBatch.Id;
                _transistorRepository.Insert(transistor).GetAwaiter().GetResult();
                _transistorRepository.ClearTracker();
                listView1.AddItemToView<Transistor>(transistor, null, true);
                UpdateDetails();
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK);
            }
            return true;
        }

        private bool HandleUpdate()
        {
            if (transistorCtrl1.Validate(out string message))
            {
                Transistor transistor = transistorCtrl1.EntityInfo.Entity;
                _transistorRepository.Update(transistor).GetAwaiter().GetResult();
                _transistorRepository.ClearTracker();
                listView1.SetItemAfterUpdate<Transistor>(transistor);
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK);
            }
            return true;
        }

        private bool HandleRemove()
        {
            Transistor transistor = listView1.GetItemForUpdate<Transistor>().Entity;
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove transistor {transistor.Idx}", "Delete", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                _transistorRepository.Delete(transistor).GetAwaiter().GetResult();
                _transistorRepository.ClearTracker();
                listView1.DeleteSelected();
                UpdateDetails();
            }
            return true;
        }

        private bool HandleRestore()
        {
            Transistor transistor = listView1.GetItemForUpdate<Transistor>().Entity;
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to restore transistor {transistor.Idx} (remove from group only)?",
                "Restore", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                transistor.GroupId = null;
                transistor.LastUpdateDate = DateTime.UtcNow;
                _transistorRepository.Update(transistor).GetAwaiter().GetResult();
                _transistorRepository.ClearTracker();
                listView1.DeleteSelected();
                UpdateDetails();
            }
            return true;
        }

        private bool HandleRestoreAll()
        {
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to restore all transistors (remove from groups only)?",
                "Restore All", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                listView1.SelectedItems.Clear();
                foreach (ListViewItem item in listView1.Items)
                {
                    Transistor transistor = (Transistor)item?.Tag;
                    transistor.GroupId = null;
                    transistor.LastUpdateDate = DateTime.UtcNow;
                    _transistorRepository.Update(transistor).GetAwaiter().GetResult();
                }
                _transistorRepository.ClearTracker();
                listView1.ClearAll();
                UpdateDetails();
            }
            return true;
        }

        private bool HandleProcess()
        {
            Batch batch = comboBoxBatches.SelectedItem as Batch;
            TransistorProcessorForm transistorProcessorForm = new TransistorProcessorForm(_batchTypeRepository, _batchRepository, _transistorRepository);
            transistorProcessorForm.LockToBatch(batch);
            transistorProcessorForm.ShowDialog(this);
            ReloadTransistors();
            return true;
        }

        private void ListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            TransistorStateItem transistorStateItem = comboBoxState.SelectedItem as TransistorStateItem;
            if (listView1.HasSelectedItem())
            {
                if (transistorStateItem.State == TransistorState.Matched)
                {
                    transistorCtrl1.Toggle(false);
                    transistorCtrl1.EntityInfo = listView1.GetItemForUpdate<Transistor>();
                    commandAndControl1.ToggleCommands(Command.Restore | Command.RestoreAll | Command.Remove);
                }
                else
                {
                    transistorCtrl1.Toggle(true);
                    transistorCtrl1.EntityInfo = listView1.GetItemForUpdate<Transistor>();
                    commandAndControl1.ToggleCommands(Command.Update | Command.Remove | Command.Process);
                }
            }
            else
            {
                if (transistorStateItem.State == TransistorState.Matched)
                {
                    transistorCtrl1.Toggle(false);
                    transistorCtrl1.EntityInfo = null;
                    commandAndControl1.ToggleCommands(Command.RestoreAll);
                }
                else
                {
                    transistorCtrl1.Toggle(true);
                    long next = _transistorRepository.FindByBatchId(ActiveBatch.Id)
                        .GetAwaiter()
                        .GetResult()
                        .DefaultIfEmpty(new Transistor { Id = 0 })
                        .Max(t => t.Idx) + 1;
                    transistorCtrl1.EntityInfo = new EntityWrapper<Transistor>
                    {
                        State = EditState.New,
                        Entity = new Transistor
                        {
                            Idx = next
                        }
                    };
                    commandAndControl1.ToggleCommands(Command.Add | Command.Process);
                }
            }
        }

        private void ResetState()
        {
            try
            {
                SupressEvents = true;
                comboBoxState.DataSource = TransistorStateItem.All;
            }
            finally
            {
                SupressEvents = false;
            }
        }

        private void ResetBatches()
        {
            try
            {
                SupressEvents = true;
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
            finally
            {
                SupressEvents = false;
            }
        }

        private void ComboBoxState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadTransistors();
        }

        private void ComboBoxBatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadTransistors();
        }

        public void ReloadTransistors()
        { 
            if (SupressEvents) return;

            listView1.ClearAll();

            Batch selectedItem = comboBoxBatches.SelectedItem as Batch;
            ActiveBatch = _batchRepository.FindByKey(selectedItem.Id, new BatchQueryFilter
            {
                IncludeBatchType = true
            }).GetAwaiter().GetResult();

            TransistorStateItem transistorStateItem = comboBoxState.SelectedItem as TransistorStateItem;
            List<Transistor> transistors; 
            if (transistorStateItem.State == TransistorState.Unmatched)
            {
                transistors = _transistorRepository.FindByBatchIdAndUnmatched(ActiveBatch.Id).GetAwaiter().GetResult();
                listView1.LoadItems<Transistor>(transistors);
            }
            else
            {
                transistors = _transistorRepository.FindByBatchIdAndMatched(ActiveBatch.Id).GetAwaiter().GetResult();
                List <TransistorGroup> batches = transistors.GroupBy(t => t.GroupId)
                    .Select(grp => new TransistorGroup(grp.ToList()))
                    .OrderByDescending(grp => grp.Count)
                    .ToList();
                int index = 1;
                foreach (TransistorGroup group in batches)
                {
                    ListViewGroup listViewGroup = new ListViewGroup($"Group {index} ({group.Count})", HorizontalAlignment.Left);
                    listView1.Groups.Add(listViewGroup);
                    group.ForEach(t => listView1.AddItemToView(t, listViewGroup));
                    index++;
                }
            }
            listView1.ResetSortOrder();
            UpdateDetails();
            ListViewSelectedIndexChanged(null, null);
        }

        public void HandleEvent(NotificationEventArgs args)
        {
            if(args.Event == EventType.BatchAdded || args.Event == EventType.BatchRemoved)
            {
                ResetBatches();
            }
        }

        public void UpdateDetails()
        {
            transistorCtrl1.Text = $"{listView1.Items.Count} transistor(s)";
        }
    }
}
