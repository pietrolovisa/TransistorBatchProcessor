using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransistorBatchProcessor
{
    public interface IEditorControl
    {
        int Height { get; set; }
        void InitializeControls();
    }
}
