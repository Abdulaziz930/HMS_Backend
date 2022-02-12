using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Entities
{
    public class RoomAmenty
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int AmentyId { get; set; }
        public Room Room { get; set; }
        public Amenty Amenty { get; set; }
    }
}
