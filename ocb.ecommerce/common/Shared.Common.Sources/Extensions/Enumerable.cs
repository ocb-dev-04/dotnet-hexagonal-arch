namespace Shared.Common.Sources.Extensions;

/// <summary>
/// <see cref="IEnumerable{T}"/> extension methods
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Extension method to paginate list
    /// </summary>
    /// <typeparam name="T">The type of entity that will be paginated</typeparam>
    /// <param name="query">Query in self</param>
    /// <param name="pageNumber">Page number to paginate</param>
    /// <param name="pageSize">The grow of result</param>
    /// <returns></returns>
    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageNumber = 1, int pageSize = 10)
        => query.Skip(pageNumber <= 1 ? 0 : pageNumber * pageSize).Take(pageSize).AsQueryable();
}
