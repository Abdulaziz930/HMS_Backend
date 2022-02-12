using HMS.Core;
using HMS.Core.Repositories;
using HMS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IAmentyRepository _amentyRepository;
        private IServiceRepository _serviceRepository;
        private IRoomTypeRepository _roomTypeRepository;
        private IRoomRepository _roomRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IAmentyRepository AmentyRepository => _amentyRepository = _amentyRepository ?? new AmentyRepository(_context);
        public IServiceRepository ServiceRepository => _serviceRepository = _serviceRepository ?? new ServiceRepository(_context);
        public IRoomTypeRepository RoomTypeRepository => _roomTypeRepository = _roomTypeRepository ?? new RoomTypeRepository(_context);
        public IRoomRepository RoomRepository => _roomRepository = _roomRepository ?? new RoomRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
