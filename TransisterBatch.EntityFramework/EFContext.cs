using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TransisterBatch.EntityFramework.Extensions;

namespace TransisterBatch.EntityFramework
{
    public partial class EFContext : DbContext
    {
        public DbSet<Domain.Batch> Batch { get; set; }
        public DbSet<Domain.Transistor> Transistor { get; set; }

        public EFContext()
        {
        }

        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.LogTo(Console.WriteLine);
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder
                .SetupDomains();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                Exception handledException = HandleException(ex);
                if (handledException != null) throw handledException;
                throw;
            }
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            try
            {
                return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            }
            catch (Exception ex)
            {
                Exception handledException = HandleException(ex);
                if (handledException != null) throw handledException;
                throw;
            }
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            try
            {
                return base.SaveChanges(acceptAllChangesOnSuccess);
            }
            catch (Exception ex)
            {
                Exception handledException = HandleException(ex);
                if (handledException != null) throw handledException;
                throw;
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Exception handledException = HandleException(ex);
                if (handledException != null) throw handledException;
                throw;
            }
        }

        private Exception HandleException(Exception ex)
        {
            try
            {
                //if (ex is IDBProviderException) return ex;
                //IDBProviderExceptionHandler service = this.GetService<IDBProviderExceptionHandler>();
                //return service?.ProcessException(ex) ?? ex;
                return ex;
            }
            catch (Exception)
            {
                return ex;
            }
        }
    }
}