using Microsoft.EntityFrameworkCore;
using SocialSciencesEF2024.TableRb3;


public partial class TableRB3Context : DbContext
{
    public DbSet<TableRB3> questionList => Set<TableRB3>();

    public TableRB3Context() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=SocialSciencesEF2024.db");
    }
   
}
