using System;

namespace CQRS_CodigoPenal.Queries
{
    public abstract class PagedQuery<T>
    {
        public SortParams<T> Sort { get; set; }
        public int PageSize { get; set; } = 25;
        public int PageNumber { get; set; } =1;
    }
    public abstract class SortParams<T>
    {
        public string Field { private get; set; }
        public string Order { private get; set; }
        public string OrderQuery { get { return !String.IsNullOrWhiteSpace(Field) && !String.IsNullOrWhiteSpace(Order) ? this.Order.Substring(0, 4).ToUpper() == "DESC" ? this.Field + " DESC" : this.Field + " ASC" : null; }}
    }
}
