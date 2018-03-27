using System.Collections.Generic;
using ToggleApp.AppService.Dto;
using ToggleApp.AppService.Interfaces;
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

        public ApplicationDto GetApplicationById(int id)
        {
            var application = _applicationRepository.GetById(id);

            if (application == null)
                throw new KeyNotFoundException();

            return new ApplicationDto { Name = application.Name };
        }
    }
}
