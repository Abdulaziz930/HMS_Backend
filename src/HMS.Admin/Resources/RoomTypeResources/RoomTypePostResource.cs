using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Admin.Resources
{
    public class RoomTypePostResource
    {
        [Required]
        public string Name { get; set; }
    }
}
