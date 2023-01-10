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
    public partial class BatchManagement : UserControl, IManagementTool
    {
        public string DisplayName => "Batch Management";

        public event EventHandler<NotificationEventArgs> OnNotify;

        private readonly IBatchTypeRepository _batchTypeRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly ITransistorRepository _transistorRepository;

        private bool SupressEvents { get; set; } = false;

        public BatchManagement(
            IBatchRepository batchRepository,
            IBatchTypeRepository batchTypeRepository,
            ITransistorRepository transistorRepository)
            : this()
        {
            _batchRepository = batchRepository;
            _batchTypeRepository = batchTypeRepository;
            _transistorRepository = transistorRepository;
        }

        public BatchManagement()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            listView1.InitListView(new ListViewColumnSorter(), ListViewSelectedIndexChanged,
                new List<Tuple<string, int, ColumnHeaderType>>
                {
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Batch.Id), 0, ColumnHeaderType.numeric) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Batch.Name), 140, ColumnHeaderType.text) },
                    { new Tuple<string, int, ColumnHeaderType>(nameof(Batch.Type), 140, ColumnHeaderType.text) }
                });
            commandAndControl1.OnCommand += CommandAndControl1_OnCommand;
        }

        private void CommandAndControl1_OnCommand(object sender, CommandArgs e)
        {
            bool _ = e.Command switch
            {
                Command.Add => HandleAdd(),
                Command.Update => HandleUpdate(),
                Command.Remove => HandleRemove(),
                _ => throw new InvalidOperationException($"Command Type [{e.Command}] has no handler.")
            };
        }

        private bool HandleAdd()
        {
            if (batchCtrl1.Validate(out string message))
            {
                Batch batch = batchCtrl1.EntityInfo.Entity;
                _batchRepository.Insert(batch).GetAwaiter().GetResult();
                batch = _batchRepository.FindByKey(batch.Id, new BatchQueryFilter
                {
                    IncludeBatchType = true
                }).GetAwaiter().GetResult();
                _batchRepository.ClearTracker();
                listView1.AddItemToView<Batch>(batch, null, true);
                OnNotify?.Invoke(this, NotificationEventArgs.BatchItemChanged(Command.Add));
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
            if (batchCtrl1.Validate(out string message))
            {
                Batch batch = batchCtrl1.EntityInfo.Entity;
                _batchRepository.Update(batch).GetAwaiter().GetResult();
                batch = _batchRepository.FindByKey(batch.Id, new BatchQueryFilter
                {
                    IncludeBatchType = true
                }).GetAwaiter().GetResult();
                _batchRepository.ClearTracker();
                listView1.SetItemAfterUpdate<Batch>(batch);
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK);
            }
            return true;
        }

        private bool HandleRemove()
        {
            Batch batch = listView1.GetItemForUpdate<Batch>().Entity;
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove batch {batch.Name}", "Delete", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                _batchRepository.Delete(batch).GetAwaiter().GetResult();
                _batchRepository.ClearTracker();
                listView1.DeleteSelected();
                UpdateDetails();
                OnNotify?.Invoke(this, NotificationEventArgs.BatchItemChanged(Command.Remove));
            }
            return true;
        }

        private void ListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            batchCtrl1.ResetBatchTypes(_batchTypeRepository.FindAll().GetAwaiter().GetResult());
            if (listView1.HasSelectedItem())
            {
                batchCtrl1.EntityInfo = listView1.GetItemForUpdate<Batch>();
                commandAndControl1.ToggleCommands(Command.Update | Command.Remove);
            }
            else
            {
                batchCtrl1.EntityInfo = listView1.GetItemForAdd<Batch>();
                commandAndControl1.ToggleCommands(Command.Add);
            }
        }

        public void InitializeView()
        {
            listView1.LoadItems<Batch>(_batchRepository.FindAll(new BatchQueryFilter
            {
                IncludeBatchType = true
            }).GetAwaiter().GetResult());
            listView1.ResetSortOrder();
            ListViewSelectedIndexChanged(null, null);
            UpdateDetails();
        }

        public void HandleEvent(NotificationEventArgs args)
        {
            if (args.Event == EventType.BatchTypeItemChanged)
            {
                if (args.Command == Command.Remove)
                {
                    InitializeView();
                }
                else
                {
                    batchCtrl1.ResetBatchTypes(_batchTypeRepository.FindAll().GetAwaiter().GetResult());
                    if (listView1.HasSelectedItem())
                    {
                        batchCtrl1.EntityInfo = listView1.GetItemForUpdate<Batch>();
                    }
                }
            }
        }

        public void UpdateDetails()
        {
            batchCtrl1.Text = $"{listView1.Items.Count} batch(s)";
        }
    }
}
