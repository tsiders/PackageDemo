using DbContextCRUDExtensions.PageAndFilters;
using PackageDemo.Entities;

namespace PackageDemo.Filters;

public class PersonFilter : BaseFilter
{
    public string? Name { get; set; }
}