using Microsoft.EntityFrameworkCore;

namespace PackageDemo;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
    {
    } 
}