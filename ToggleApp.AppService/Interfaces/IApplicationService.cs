using System.Threading.Tasks;
using ToggleApp.Domain.Entities;

namespace ToggleApp.AppService.Interfaces
{
    public interface IApplicationService
    {
        Task<Application> GetApplicationByIdAsync(int id);
    }
}
