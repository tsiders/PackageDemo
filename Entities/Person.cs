using System.ComponentModel.DataAnnotations;
using DbContextCRUDExtensions.Entities;

namespace PackageDemo.Entities;

public class Person : BaseEntity
{
    [Required]
    public string? Name { get; set; }
}