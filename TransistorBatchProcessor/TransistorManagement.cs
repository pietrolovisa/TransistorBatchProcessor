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
            ResetBatches();
        }

        private void ListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.HasSelectedItem())
            {
                transistorCtrl1.EntityInfo = listView1.GetItemForUpdate<Transistor>();
                buttonAddOrUpdate.Text = "Update";
                buttonRemove.Enabled = true;
            }
            else
            {
                long next = ActiveBatch.Transistors.Max(t => t.Idx) + 1;
                transistorCtrl1.EntityInfo = new EntityWrapper<Transistor>
                {
                    State = EditState.New,
                    Entity = new Transistor
                    {
                        Idx = next
                    }
                };
                buttonAddOrUpdate.Text = "Add";
                buttonRemove.Enabled = false;
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

        private void ComboBoxBatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SupressEvents) return;

            Batch selectedItem = comboBoxBatches.SelectedItem as Batch;
            ActiveBatch = _batchRepository.FindByKey(selectedItem.Id, new BatchQueryFilter
            {
                IncludeBatchType = true,
                IncludeTransistors = true
            }).GetAwaiter().GetResult();
            LoadTransistors();
            if (listView1.Items.Count > 0)
            {
                listView1.Items[0].ForceSelected();
            }
            else
            {
                transistorCtrl1.EntityInfo = new EntityWrapper<Transistor>
                {
                    State = EditState.New,
                    Entity = new Transistor
                    {
                        Idx = 1
                    }
                };
                buttonAddOrUpdate.Text = "Add";
            }
        }

        private void LoadTransistors()
        {
            listView1.LoadItems<Transistor>(ActiveBatch.Transistors);
            listView1.ResetSortOrder();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            Transistor transistor = listView1.GetItemForUpdate<Transistor>().Entity;
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove transistor {transistor.Idx}", "Delete", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                _transistorRepository.Delete(transistor).GetAwaiter().GetResult();
            }
        }

        private void AddOrUpdate_Click(object sender, EventArgs e)
        {
            if (transistorCtrl1.Validate(out string message))
            {
                if (transistorCtrl1.EntityInfo.State == EditState.New)
                {
                    Transistor transistor = transistorCtrl1.EntityInfo.Entity;
                    transistor.BatchId = ActiveBatch.Id;
                    _transistorRepository.Insert(transistor).GetAwaiter().GetResult();
                    ActiveBatch.Transistors.Add(transistor);
                    listView1.AddItemToView<Transistor>(transistor, null, true);
                }
                else
                {
                    Transistor transistor = transistorCtrl1.EntityInfo.Entity;
                    _transistorRepository.Update(transistor).GetAwaiter().GetResult();
                    listView1.SetItemAfterUpdate<Transistor>(transistor);
                }
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK);
            }
        }

        public void HandleEvent(NotificationEventArgs args)
        {
            if(args.Event == EventType.BatchAdded || args.Event == EventType.BatchRemoved)
            {
                ResetBatches();
            }
        }
    }

    public interface IManagementTool
    {
        string DisplayName { get; }

        void InitializeView();
        void HandleEvent(NotificationEventArgs args);

        event EventHandler<NotificationEventArgs> OnNotify;
    }
}
