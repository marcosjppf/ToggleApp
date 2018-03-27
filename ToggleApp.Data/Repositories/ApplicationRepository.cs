using System.Collections.Generic;
using System.Linq;
using ToggleApp.Data.Context;
using ToggleApp.Domain.Entities;
using ToggleApp.Domain.Repositories;

namespace ToggleApp.Data.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ToggleAppDbContext _toggleAppDbContext;

        public ApplicationRepository(ToggleAppDbContext toggleAppDbContext)
        {
            _toggleAppDbContext = toggleAppDbContext;
        }

        public IEnumerable<Application> GetAll()
        {
            return _toggleAppDbContext.Applications.ToList();
        }

        public Application GetById(int id)
        {
            return _toggleAppDbContext.Applications.Find(id);
        }
    }
}