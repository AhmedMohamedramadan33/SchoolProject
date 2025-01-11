using Microsoft.EntityFrameworkCore;

namespace School.Core.Paginated
{
    public static class QueryableExtensions
    {
        //public static async Task<PaginatedResponse<T>> ToPaginatedList<T>(this IQueryable<T> source, int pagenumber, int pagesize,
        //    Expression<Func<T, bool>> search = null, Expression<Func<T, object>> orderby = null, Expression<Func<T, object>> orderbydesc = null) where T : class
        //{
        //    if (source == null) throw new Exception();
        //    pagenumber = pagenumber <= 0 ? 1 : pagenumber;
        //    pagesize = pagesize == 0 ? 5 : pagesize;

        //    int count = await source.AsNoTracking().CountAsync();
        //    if (count == 0)
        //    {
        //        return PaginatedResponse<T>.Success(new List<T>(), count, pagenumber, pagesize);
        //    }
        //    if (search != null)
        //    {
        //        source = source.Where(search);
        //    }
        //    if (orderby != null)
        //    {
        //        source = source.OrderBy(orderby);
        //    }
        //    if (orderbydesc != null)
        //    {
        //        source = source.OrderByDescending(orderbydesc);
        //    }
        //    var res = await source.Skip((pagenumber - 1) * pagesize).Take(pagesize).ToListAsync();
        //    return PaginatedResponse<T>.Success(res, count, pagenumber, pagesize);

        //}
        public static async Task<PaginatedResponse<T>> ToPaginatedList<T>(this IQueryable<T> source, int pagenumber, int pagesize) where T : class
        {
            if (source == null) throw new Exception();
            pagenumber = pagenumber <= 0 ? 1 : pagenumber;
            pagesize = pagesize == 0 ? 5 : pagesize;

            int count = await source.AsNoTracking().CountAsync();
            if (count == 0)
            {
                return PaginatedResponse<T>.Success(new List<T>(), count, pagenumber, pagesize);
            }
            var res = await source.Skip((pagenumber - 1) * pagesize).Take(pagesize).ToListAsync();
            return PaginatedResponse<T>.Success(res, count, pagenumber, pagesize);
        }
    }
}
