using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TransisterBatch.EntityFramework
{
    public class EFContextFactory : IDesignTimeDbContextFactory<EFContext>
    {
        public EFContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFContext>();
            optionsBuilder.UseSqlite("Data Source=database\\Jeff.db;Cache=Shared");

            return new EFContext(optionsBuilder.Options);
        }
    }
}
