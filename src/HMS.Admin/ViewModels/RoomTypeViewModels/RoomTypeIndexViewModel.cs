using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Admin.ViewModels
{
    public class RoomTypeIndexViewModel
    {
        public IEnumerable<RoomTypeListItemViewModel> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public bool HasPrev { get; set; }
        public bool HasNext { get; set; }
    }

    public class RoomTypeListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
