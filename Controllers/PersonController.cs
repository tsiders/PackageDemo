using DbContextCRUDExtensions;
using DbContextCRUDExtensions.PageAndFilters;
using Microsoft.AspNetCore.Mvc;
using PackageDemo.Dtos;
using PackageDemo.Entities;
using PackageDemo.Filters;

namespace PackageDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ProjectDbContext _dbContext;

    public PersonController(ProjectDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromBody] PersonDto personDto)
    {
        var result = await _dbContext.CreateEntity(personDto, Person.CreateFromPersonDto);
        
        return Ok(PersonDto.CreateFromEntity(result));
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchPeople([FromQuery] Page page, [FromQuery] PersonFilter filter,
        [FromQuery] string[]? includes = null)
    {
        var result = await _dbContext.SearchAsync<Person, PersonDto, PersonFilter>(
            new PageAndFilter<PersonFilter>(page, filter), 
            PersonDto.CreateFromEntity, 
            PersonFilter.ApplyFilter, 
            includes);

        return Ok(result);
    }
}