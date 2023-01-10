using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using TransisterBatch.EntityFramework.Extensions;

namespace TransisterBatch.EntityFramework.Domain
{
    public class Transistor : TableBase
    {
        public long Idx { get; set; }
        public double HEF { get; set; }
        public double Beta { get; set; }
        public long BatchId { get; set; }
        public string GroupId { get; set; }

        public Batch Batch { get; set; }

        public static void Setup(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transistor>(table =>
            {
                table.ToTable(nameof(Transistor));

                table.HasKey(e => e.Id);

                table.Property(e => e.HEF)
                    .IsRequired();

                table.Property(e => e.Beta)
                    .IsRequired();

                table.HasOne(e => e.Batch)
                    .WithMany(e => e.Transistors)
                    .HasForeignKey(e => new { e.BatchId })
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public override List<string> ToStrings => new List<string>
        {
            Id.ToString(),
            Idx.ToString(),
            HEF.ToString(),
            Beta.ToString()
        };
    }

    public class TransistorGroup : List<Transistor>
    {
        public TransistorGroup()
        {
        }

        public TransistorGroup(IEnumerable<Transistor> seed)
            : base(seed)
        {
        }

        public List<TransistorGroup> Process(TransistorGroupLoadArgs args)
        {
            List<TransistorGroup> batches = this
                .GroupBy(ts => ts, new TransistorEqualityComparer
                {
                    BetaTolerance = args.BetaTolerance,
                    HefTolerance = args.HefTolerance
                })
                .Select(grp => new TransistorGroup(grp.ToList()))
                .OrderByDescending(grp => grp.Count)
                .ToList();
            return batches;
        }
    }

    public class TransistorGroupLoadArgs
    {
        public double BetaTolerance { get; set; } = 0.001;
        public int HefTolerance { get; set; } = 0;
    }

    public class TransistorEqualityComparer : IEqualityComparer<Transistor>
    {
        public double BetaTolerance { get; set; } = 0.001;
        public double HefTolerance { get; set; } = 0;

        public bool Equals(Transistor x, Transistor y)
        {
            return x.HEF == y.HEF &&
                x.Beta - BetaTolerance <= y.Beta && x.Beta + BetaTolerance >= y.Beta;
        }

        public int GetHashCode(Transistor obj) => 1;
    }
}
