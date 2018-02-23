using System.Data.Entity;

namespace Db
{
    public class HangmanContext : DbContext
    {
        public DbSet<Word> Words { get; set; }
    }
}
