using DbContextCRUDExtensions.PageAndFilters;
using PackageDemo.Entities;

namespace PackageDemo.Filters;

public class PersonFilter
{
    public string? Name { get; set; }
    
    public static IQueryable<Person> ApplyFilter(PersonFilter filter, IQueryable<Person> query)
    {
        if (!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(p => p.Name.Contains(filter.Name));
        }

        return query;
    }
}