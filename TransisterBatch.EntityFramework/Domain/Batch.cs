using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TransisterBatch.EntityFramework.Extensions;

namespace TransisterBatch.EntityFramework.Domain
{
    public class Batch : TableBase
    {
        public string Name { get; set; }
        public long BatchTypeId { get; set; }
        [NotMapped]
        public string Description => $"{Name} ({Type?.Name})";

        public BatchType Type { get; set; }
        public List<Transistor> Transistors { get; set; }

        public static void Setup(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batch>(table =>
            {
                table.ToTable(nameof(Batch));

                table.HasKey(e => e.Id);

                table.Property(e => e.Name)
                    .IsReqiredWithMaxLength(512);

                table.HasOne(e => e.Type)
                    .WithMany(e => e.Batches)
                    .HasForeignKey(e => new { e.BatchTypeId })
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public override List<string> ToStrings => new List<string>
                {
                    Id.ToString(),
                    Name,
                    Type?.Name
                };
    }
}
