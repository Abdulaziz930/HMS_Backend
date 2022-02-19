using HMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Repositories
{
    public interface ISettingRepository : IRepository<Setting>
    {
        Task<Dictionary<string, string>> GetKeyValueSettingsAsync(Expression<Func<Setting, bool>> filter = null, params string[] includes);
    }
}
