using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Admin.ViewModels
{
    public class RoomTypePostViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
