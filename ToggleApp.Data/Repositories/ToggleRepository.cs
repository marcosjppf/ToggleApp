using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToggleApp.Data.Context;
using ToggleApp.Domain.Entities;
using ToggleApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ToggleApp.Data.Repositories
{
    public class ToggleRepository : IToggleRepository
    {
        private readonly ToggleAppDbContext _toggleAppDbContext;

        public ToggleRepository(ToggleAppDbContext webAppDbContext)
        {
            _toggleAppDbContext = webAppDbContext;
        }

        public async Task<IEnumerable<Toggle>> GetAllAsync()
        {
            return await _toggleAppDbContext.Toggles.ToListAsync();
        }

        public async Task<Toggle> GetByIdAsync(int id)
        {
            return await _toggleAppDbContext.Toggles.FindAsync(id);
        }

        public IEnumerable<Toggle> GetFromApplication(int applicationId, string version)
        {
            return _toggleAppDbContext.Toggles.Where(t => t.AcessibleTo(applicationId, version));
        }

        public async Task<Toggle> AddAsync(Toggle toggle)
        {
            _toggleAppDbContext.Add(toggle);
            await _toggleAppDbContext.SaveChangesAsync();
            return toggle;
        }

        public async Task<Toggle> UpdateAsync(Toggle toggle)
        {
            _toggleAppDbContext.Update(toggle);
            await _toggleAppDbContext.SaveChangesAsync();
            return toggle;
        }

        public async Task DeleteAsync(Toggle toggle)
        {
            _toggleAppDbContext.Remove(toggle);
            await _toggleAppDbContext.SaveChangesAsync();
        }
    }
}
