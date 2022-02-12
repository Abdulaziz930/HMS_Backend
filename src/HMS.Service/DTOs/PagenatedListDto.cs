using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.DTOs
{
    public class PagenatedListDto<T>
    {
        public PagenatedListDto(IEnumerable<T> items, int totalCount, int pageIndex, int pageSize)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            HasPrev = PageIndex > 1;
            HasNext = PageIndex < TotalPages;
        }

        public IEnumerable<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrev { get; set; }
        public bool HasNext { get; set; }
    }
}
