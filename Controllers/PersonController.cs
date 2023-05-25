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
        var result = await _dbContext.CreateEntity(personDto, p =>
        {
            return new Person()
            {
                Id = null,
                Name = p.Name
            };
        });

        personDto.Id = result.Id;
        
        return Ok(personDto);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchPeople([FromQuery] Page page, [FromQuery] PersonFilter filter,
        [FromQuery] string[]? includes = null)
    {
        var result = await _dbContext.SearchAsync<Person, PersonDto, PersonFilter>(new PageAndFilter<PersonFilter>(page, filter), 
            (p) => new PersonDto
        {
            Id = p.Id,
            Name = p.Name
        }, (f, q) =>
        {
            if (!string.IsNullOrEmpty(f.Name))
            {
                q = q.Where(p => p.Name.ToLower().Contains(f.Name));
            }
            
            return q;
        }, includes);

        return Ok(result);
    }
}