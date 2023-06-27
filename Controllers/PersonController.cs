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

    [HttpPost("async")]
    public async Task<IActionResult> CreatePersonAsync([FromBody] PersonDto personDto)
    {
        var result =  await _dbContext.CreateEntityAsync(personDto, Person.CreateFromPersonDto, true);

        return Ok(PersonDto.CreateFromEntity(result));
    }
    
    [HttpPost("async-conversion")]
    public async Task<IActionResult> CreatePersonAsyncConversion([FromBody] PersonDto personDto)
    {
        var result = await _dbContext.CreateEntityAsync(personDto, async (dto) => await Person.CreateFromPersonDtoAsync(dto), true);
        
        return Ok(PersonDto.CreateFromEntity(result));
    }
    
    [HttpPost]
    public IActionResult CreatePerson([FromBody] PersonDto personDto)
    {
        var result =  _dbContext.CreateEntity(personDto, Person.CreateFromPersonDto, true);

        return Ok(PersonDto.CreateFromEntity(result));
    }

    [HttpGet("search-async")]
    public async Task<IActionResult> SearchPeopleAsync([FromQuery] Page page, [FromQuery] PersonFilter filter,
        [FromQuery] string[]? includes = null)
    {
        var result = await _dbContext.SearchAsync<Person, PersonDto, PersonFilter>(
            new PageAndFilter<PersonFilter>(page, filter), 
            PersonDto.CreateFromEntity, 
            PersonFilter.ApplyFilter, 
            includes);

        return Ok(result);
    }
    
    [HttpGet("search")]
    public IActionResult SearchPeople([FromQuery] Page page, [FromQuery] PersonFilter filter,
        [FromQuery] string[]? includes = null)
    {
        var result = _dbContext.Search<Person, PersonDto, PersonFilter>(
            new PageAndFilter<PersonFilter>(page, filter), 
            PersonDto.CreateFromEntity, 
            PersonFilter.ApplyFilter, 
            includes);

        return Ok(result);
    }
}