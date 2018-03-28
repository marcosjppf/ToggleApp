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

        public async Task<ApplicationDto> GetApplicationById(int id)
        {
            var application = await _applicationRepository.GetById(id);

            if (application == null)
                throw new KeyNotFoundException();

            return ApplicationMapper.ToApplicationDto(application);
        }
    }
}
