using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Entities
{
    public class RoomService
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int ServiceId { get; set; }
        public Room Room { get; set; }
        public Service Service { get; set; }
    }
}
