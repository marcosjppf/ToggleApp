using System.Collections.Generic;
using ToggleApp.Domain.Entities;
using System.Threading.Tasks;

namespace ToggleApp.Domain.Repositories
{
    public interface IToggleRepository
    {
        Task<IEnumerable<Toggle>> GetAllAsync();
        Task<Toggle> GetByIdAsync(int id);
        IEnumerable<Toggle> GetFromApplication(int applicationId, string version);
        Task AddAsync(Toggle toggle);
        Task UpdateAsync(Toggle toggle);
        Task DeleteAsync(Toggle toggle);
    }
}
