using System.Collections.Generic;
using System.Threading.Tasks;
using ToggleApp.Domain.Entities;

namespace ToggleApp.AppService.Interfaces
{
    public interface IToggleService
    {
        Toggle GetToggleById(int id);
        IEnumerable<Toggle> GetAllToggles();
        Task AddToggleAsync(Toggle toggle);
        Task UpdateToggleAsync(Toggle toggle);
        Task DeleteToggleAsync(int id);
    }
}
