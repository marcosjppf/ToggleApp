using System.Collections.Generic;
using System.Linq;
using ToggleApp.Data.Context;
using ToggleApp.Domain.Entities;
using ToggleApp.Domain.Repository;

namespace ToggleApp.Data.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ToggleAppDbContext _webAppDbContext;

        public ApplicationRepository(ToggleAppDbContext webAppDbContext)
        {
            _webAppDbContext = webAppDbContext;
        }

        public void Add(Application application)
        {
            _webAppDbContext.Add(application);
            _webAppDbContext.SaveChanges();
        }

        public IEnumerable<Application> Get()
        {
            return _webAppDbContext.Applications.ToList();
        }

        public Application Get(int id)
        {
            return _webAppDbContext.Applications.FirstOrDefault(app => app.Id == id);
        }
    }
}
