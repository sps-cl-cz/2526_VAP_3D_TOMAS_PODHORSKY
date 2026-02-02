using Microsoft.EntityFrameworkCore;

namespace DatabaseAppEf
{
    public class SQLiteDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Notes.db");
        }
    }
}
