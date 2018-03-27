using System.Collections.Generic;
using ToggleApp.Domain.Entities;

namespace ToggleApp.Domain.Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        IEnumerable<Application> GetAll();
        Application GetById(int id);
    }
}
