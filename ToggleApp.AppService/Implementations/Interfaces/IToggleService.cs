using System.Collections.Generic;
using System.Threading.Tasks;
using ToggleApp.AppService.Dto;

namespace ToggleApp.AppService.Implementations
{
    public interface IToggleService
    {
        Task<ToggleDto> GetToggleByIdAsync(int id);
        Task<IEnumerable<ToggleDto>> GetAllTogglesAsync();
        IEnumerable<ToggleDto> GetAllTogglesFromApplicationAsync(int applicationId, string version);
        Task AddToggleAsync(ToggleDto toggle);
        Task UpdateToggleAsync(ToggleDto toggle);
        Task DeleteToggleAsync(int id);
    }
}
