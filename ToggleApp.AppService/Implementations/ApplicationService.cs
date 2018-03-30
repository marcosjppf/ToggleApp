using System.Threading.Tasks;
using ToggleApp.AppService.Interfaces;
using ToggleApp.Domain.Entities;
using ToggleApp.Domain.Repositories;

namespace ToggleApp.AppService.Implementations
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<Application> GetApplicationByIdAsync(int id)
        {
            return await _applicationRepository.GetByIdAsync(id);
        }
    }
}
