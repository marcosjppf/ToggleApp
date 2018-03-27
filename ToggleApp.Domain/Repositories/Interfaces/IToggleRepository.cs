using System.Collections.Generic;
using ToggleApp.Domain.Entities;
using System.Threading.Tasks;

namespace ToggleApp.Domain.Repositories.Interfaces
{
    public interface IToggleRepository
    {
        IEnumerable<Toggle> GetAll();
        Toggle GetById(int id);
        IEnumerable<Toggle> GetFromApplication(int applicationId, string version);
        Task AddAsync(Toggle toggle);
        Task UpdateAsync(Toggle toggle);
        Task DeleteAsync(Toggle toggle);
    }
}
