using ToggleApp.AppService.Dto;
using ToggleApp.Domain.Entities;

namespace ToggleApp.AppService.Tools
{
    public static class ApplicationMapper
    {
        public static ApplicationDto ToApplicationDto(Application application)
        {
            return application == null ? null :
                new ApplicationDto
                {
                    Id = application.Id,
                    Name = application.Name
                };
        }

        public static Application ToApplication(ApplicationDto applicationDto)
        {
            return applicationDto == null ? null :
                new Application
                {
                    Id = applicationDto.Id,
                    Name = applicationDto.Name
                };
        }
    }
}
