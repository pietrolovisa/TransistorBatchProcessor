
namespace TransisterBatch.EntityFramework.Domain
{
    public abstract class TableBase : ITableBase
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdateDate { get; set; } = DateTime.UtcNow;
        public bool Inactive { get; set; } = false;

        public abstract List<string> ToStrings { get; }
    }

    public interface ITableBase
    {
        DateTime CreateDate { get; set; }
        DateTime LastUpdateDate { get; set; }
        bool Inactive { get; set; }

        List<string> ToStrings { get; }
    }
}
