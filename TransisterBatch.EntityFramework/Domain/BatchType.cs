using Microsoft.EntityFrameworkCore;
using TransisterBatch.EntityFramework.Extensions;

namespace TransisterBatch.EntityFramework.Domain
{
    public class BatchType : TableBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Batch> Batches { get; set; }

        public static void Setup(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BatchType>(table =>
            {
                table.ToTable(nameof(BatchType));

                table.HasKey(e => e.Id);

                table.Property(e => e.Name)
                    .IsReqiredWithMaxLength(512);

                table.Property(e => e.Description)
                    .IsReqiredWithMaxLength(512);
            });
        }

        public override List<string> ToStrings => new List<string>
        {
            Id.ToString(),
            Name,
            Description
        };
    }
}
