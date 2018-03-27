using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToggleApp.Data.Context;
using ToggleApp.Domain.Entities;
using ToggleApp.Domain.Repositories.Interfaces;

namespace ToggleApp.Data.Repositories
{
    public class ToggleRepository : IToggleRepository
    {
        private readonly ToggleAppDbContext _toggleAppDbContext;

        public ToggleRepository(ToggleAppDbContext webAppDbContext)
        {
            _toggleAppDbContext = webAppDbContext;
        }

        public IEnumerable<Toggle> GetAll()
        {
            return _toggleAppDbContext.Toggles.ToList();
        }

        public Toggle GetById(int id)
        {
            return _toggleAppDbContext.Toggles.Find(id);
        }

        public IEnumerable<Toggle> GetFromApplication(int applicationId, string version)
        {
            return _toggleAppDbContext.Toggles.Where(t => t.AcessibleTo(applicationId, version));
        }

        public async Task AddAsync(Toggle toggle)
        {
            _toggleAppDbContext.Add(toggle);
            await _toggleAppDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Toggle toggle)
        {
            _toggleAppDbContext.Update(toggle);
            await _toggleAppDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Toggle toggle)
        {
            _toggleAppDbContext.Remove(toggle);
            await _toggleAppDbContext.SaveChangesAsync();
        }
    }
}
