using System.Collections.Generic;
using System.ComponentModel;

namespace CQRS_CodigoPenal.Results
{
    public class PaginationResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 25;
        public int TotalItems { get; set; }
        public int TotalPages { get { return TotalItems > PageSize ? this.TotalItems / this.PageSize : 1; } }
    }
}
