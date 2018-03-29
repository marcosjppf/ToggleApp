using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToggleApp.Data.Context;
using ToggleApp.Domain.Entities;
using ToggleApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ToggleApp.Data.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ToggleAppDbContext _toggleAppDbContext;

        public ApplicationRepository(ToggleAppDbContext toggleAppDbContext)
        {
            _toggleAppDbContext = toggleAppDbContext;
        }

        public async Task<IEnumerable<Application>> GetAllAsync()
        {
            return await _toggleAppDbContext.Applications.ToListAsync();
        }

        public async Task<Application> GetByIdAsync(int id)
        {
            return await _toggleAppDbContext.Applications.FindAsync(id);
        }
    }
}