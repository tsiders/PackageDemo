using System.ComponentModel.DataAnnotations;
using DbContextCRUDExtensions.Entities;
using PackageDemo.Dtos;

namespace PackageDemo.Entities;

public class Person : BaseEntity
{
    [Required]
    public string? Name { get; set; }

    public static async Task<Person> CreateFromPersonDtoAsync(PersonDto dto)
    {
        return new Person
        {
            Id = null,
            Name = dto.Name
        };
    }
    
    public static Person CreateFromPersonDto(PersonDto dto)
    {
        return new Person
        {
            Id = null,
            Name = dto.Name
        };
    }
}