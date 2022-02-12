using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Entities
{
    public class RoomImage : BaseEntity
    {
        public int RoomId { get; set; }
        public string Image { get; set; }
        public bool IsMain { get; set; }
        public Room Room { get; set; }
    }
}
