using HMS.Core.Entities;
using HMS.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Data.Repositories
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        private readonly AppDbContext _context;

        public SettingRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, string>> GetKeyValueSettingsAsync(Expression<Func<Setting, bool>> filter = null, params string[] includes)
        {
            var settings = _context.Settings.AsQueryable();

            if(includes != null && includes.Count() > 0)
            {
                foreach (var item in includes)
                {
                    settings = settings.Include(item);
                }
            }

            return await settings.ToDictionaryAsync(x => x.Key, x => x.Value);
        }
    }
}
