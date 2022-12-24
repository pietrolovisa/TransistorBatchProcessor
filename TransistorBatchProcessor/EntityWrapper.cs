using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransistorBatchProcessor
{
    public enum EditState
    {
        New,
        Update
    }

    public class EntityWrapper<T>
    {
        public T Entity { get; set; }
        public EditState State { get; set; }
    }
}
