using PackageDemo.Entities;

namespace PackageDemo.Dtos;

public class PersonDto
{
    public int? Id { get; set; }
    
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