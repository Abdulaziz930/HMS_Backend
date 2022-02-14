using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Admin.Resources
{
    public class RoomTypeIndexResource
    {
        public IEnumerable<RoomTypeListItemResource> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public bool HasPrev { get; set; }
        public bool HasNext { get; set; }
    }

    public class RoomTypeListItemResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
