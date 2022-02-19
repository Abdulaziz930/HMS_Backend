using HMS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core
{
    public interface IUnitOfWork
    {
        public IAmentyRepository AmentyRepository { get; }
        public IServiceRepository ServiceRepository { get; }
        public IRoomTypeRepository RoomTypeRepository { get; }
        public IRoomRepository RoomRepository { get; }
        public ISettingRepository SettingRepository { get; }

        Task<int> CommitAsync();
    }
}
