using System.Collections.Generic;
using System.Threading.Tasks;
using ToggleApp.AppService.Dto;
using ToggleApp.AppService.Tools;
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

        public async Task<ApplicationDto> GetApplicationByIdAsync(int id)
        {
            var application = await _applicationRepository.GetByIdAsync(id);

            if (application == null)
                return null;

            return ApplicationMapper.ToApplicationDto(application);
        }
    }
}
