using Microsoft.EntityFrameworkCore;
public class CollegeDbContext: DbContext
{
    public DbSet<Course> Courses { get; set; }
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=CollegeManagement.db");
    }
}