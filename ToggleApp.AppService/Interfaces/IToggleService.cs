using System.Collections.Generic;
using System.Threading.Tasks;
using ToggleApp.Domain.Entities;

namespace ToggleApp.AppService.Interfaces
{
    public interface IToggleService
    {
        Task<Toggle> GetToggleByIdAsync(int id);
        Task<IEnumerable<Toggle>> GetAllTogglesAsync();
        IEnumerable<Toggle> GetAllTogglesFromApplicationAsync(int applicationId, string version);
        Task<Toggle> AddToggleAsync(Toggle toggle);
        Task<Toggle> UpdateToggleAsync(Toggle toggle);
        Task DeleteToggleAsync(Toggle toggle);
    }
}
