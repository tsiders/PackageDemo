using System.ComponentModel.DataAnnotations;
using PackageDemo.Dtos;

namespace PackageDemo.Entities;

public class Person
{
    [Required]
    [Key]
    public int? Id { get; set; }
    
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