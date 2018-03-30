using System.Collections.Generic;
using ToggleApp.Domain.Entities;

namespace ToggleApp.AppService.Test
{
    public static class ApplicationHelper
    {
        public static IEnumerable<Application> ToggleList() =>
            new List<Application> {
                NewToggleConstructor(1, "Abc"),
                NewToggleConstructor(2, "Xyz")
            };

        public static Application NewToggleConstructor(int applicationId, string applicationName)
        {
            return new Application
            {
                Id = applicationId,
                Name = applicationName
            };
        }
    }
}
