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
                    Name = application.Name
                };
        }
    }
}
