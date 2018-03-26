using System.Collections.Generic;
using ToggleApp.Domain.Entities;

namespace ToggleApp.Domain.Repository
{
    public interface IApplicationRepository
    {
        void Add(Application application);
        IEnumerable<Application> Get();
        Application Get(int id);
    }
}
