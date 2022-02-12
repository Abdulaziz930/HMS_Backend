using HMS.Core.Entities;
using HMS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Data.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
