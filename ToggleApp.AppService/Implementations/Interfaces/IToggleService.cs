using System.Collections.Generic;
using System.Threading.Tasks;
using ToggleApp.AppService.Dto;

namespace ToggleApp.AppService.Implementations
{
    public interface IToggleService
    {
        Task<ToggleDto> GetToggleById(int id);
        Task<IEnumerable<ToggleDto>> GetAllToggles();
        Task AddToggleAsync(ToggleDto toggle);
        Task UpdateToggleAsync(ToggleDto toggle);
        Task DeleteToggleAsync(int id);
    }
}
