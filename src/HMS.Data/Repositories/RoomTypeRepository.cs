using HMS.Core.Entities;
using HMS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Data.Repositories
{
    public class RoomTypeRepository : Repository<RoomType>, IRoomTypeRepository
    {
        private readonly AppDbContext _context;

        public RoomTypeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
