using HMS.Core.Entities;
using HMS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Data.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
