using DbContextCRUDExtensions.Dtos;
using PackageDemo.Entities;

namespace PackageDemo.Dtos;

public class PersonDto : BaseDto
{
    public string? Name { get; set; }

    public PersonDto()
    {
    }

    public static PersonDto CreateFromEntity(Person person)
    {
        return new PersonDto
        {
            Id = person.Id,
            Name = person.Name
        };
    }
}