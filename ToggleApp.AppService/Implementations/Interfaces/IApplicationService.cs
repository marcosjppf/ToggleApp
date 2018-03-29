using System.Threading.Tasks;
using ToggleApp.AppService.Dto;

namespace ToggleApp.AppService.Implementations
{
    public interface IApplicationService
    {
        Task<ApplicationDto> GetApplicationByIdAsync(int id);
    }
}
