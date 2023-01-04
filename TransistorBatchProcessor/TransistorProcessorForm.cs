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

namespace TransistorBatchProcessor
{
    public partial class TransistorProcessorForm : Form
    {
        private readonly IBatchTypeRepository _batchTypeRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly ITransistorRepository _transistorRepository;

        private Processor Processor { get; set; }

        public TransistorProcessorForm(IBatchTypeRepository batchTypeRepository,
            IBatchRepository batchRepository,
            ITransistorRepository transistorRepository)
        {
            _batchTypeRepository = batchTypeRepository;
            _batchRepository = batchRepository;
            _transistorRepository = transistorRepository;

            Processor = new Processor(_batchRepository, _batchTypeRepository, _transistorRepository);
            Processor.InitializeView();
            Processor.Dock = DockStyle.Fill;
            Controls.Add(Processor);

            InitializeComponent();
        }

        public void LockToBatch(Batch batch)
        {
            
            Processor.LockToBatch(batch);
        }
    }
}
