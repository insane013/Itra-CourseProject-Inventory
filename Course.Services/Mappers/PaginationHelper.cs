using System.Threading.Tasks;
using Course.Core;
using Microsoft.EntityFrameworkCore;

namespace Course.Services.Mapper;

public static class PaginationHelper
{
    public static async Task<PaginatedResult<TOut>> Paginate<TIn, TOut>(
        IQueryable<TIn> source,
        int pageNumber,
        int pageSize,
        Func<TIn, TOut> map)
    {
        var count = await source.CountAsync();

        var paged = await source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var mapped = paged.Select(map).ToList();

        return new PaginatedResult<TOut>
        {
            TotalItems = count,
            PageSize = pageSize,
            CurrentPage = pageNumber,
            PageCount = (int)Math.Ceiling(count / (double)pageSize),
            Items = mapped,
        };
    }
}
