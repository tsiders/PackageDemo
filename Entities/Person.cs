using System.ComponentModel.DataAnnotations;
using DbContextCRUDExtensions.Entities;
using PackageDemo.Dtos;

namespace PackageDemo.Entities;

public class Person : BaseEntity
{
    [Required]
    public string? Name { get; set; }

    public static Person CreateFromPersonDto(PersonDto dto)
    {
        return new Person
        {
            Id = null,
            Name = dto.Name
        };
    } 
}