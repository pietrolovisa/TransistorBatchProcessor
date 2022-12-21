using Microsoft.EntityFrameworkCore;
using TransisterBatch.EntityFramework.Extensions;

namespace TransisterBatch.EntityFramework.Domain
{
    public class Transistor : TableBase
    {
        public long Idx { get; set; }
        public double HEF { get; set; }
        public double Beta { get; set; }
        public long BatchId { get; set; }

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
                    .HasForeignKey(e => new { e.BatchId });
            });
        }
    }
}
