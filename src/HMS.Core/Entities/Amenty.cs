using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Entities
{
    public class Amenty : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public ICollection<RoomAmenty> RoomAmenties { get; set; }
    }
}
