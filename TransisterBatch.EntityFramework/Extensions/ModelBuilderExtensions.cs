using Microsoft.EntityFrameworkCore;

namespace TransisterBatch.EntityFramework.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder SetupDomains(this ModelBuilder modelBuilder)
        {
            Domain.Batch.Setup(modelBuilder);
            Domain.Transistor.Setup(modelBuilder);
            return modelBuilder;
        }
    }
}
