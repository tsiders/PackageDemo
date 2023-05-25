using DbContextCRUDExtensions.Dtos;

namespace PackageDemo.Dtos;

public class PersonDto : BaseDto
{
    public string? Name { get; set; }
}