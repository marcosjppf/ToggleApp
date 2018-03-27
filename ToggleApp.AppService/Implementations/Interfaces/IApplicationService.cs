using System.Collections.Generic;
using ToggleApp.AppService.Dto;
using ToggleApp.Domain.Entities;

namespace ToggleApp.AppService.Implementations.Interfaces
{
    public interface IApplicationService
    {
        ApplicationDto GetApplicationById(int id);
    }
}
