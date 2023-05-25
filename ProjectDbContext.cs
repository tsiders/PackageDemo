using Microsoft.EntityFrameworkCore;
using PackageDemo.Entities;

namespace PackageDemo;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
    {
    }
    
    public DbSet<Person> People { get; set; }
}