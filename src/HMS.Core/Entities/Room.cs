using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Entities
{
    public class Room : BaseEntity
    {
        public int RoomTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DiscountPercent { get; set; }
        public int AdultCapacity { get; set; }
        public int ChildrenCapacity { get; set; }
        public decimal Size { get; set; }
        public string Location { get; set; }
        public bool IsFeatured { get; set; }
        public RoomType RoomType { get; set; }
        public ICollection<RoomImage> RoomImages { get; set; }
        public ICollection<RoomAmenty> RoomAmenties { get; set; }
        public ICollection<RoomService> RoomServices { get; set; }
    }
}
