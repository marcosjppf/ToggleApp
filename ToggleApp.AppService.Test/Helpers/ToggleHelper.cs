using System.Collections.Generic;
using ToggleApp.Domain.Entities;

namespace ToggleApp.AppService.Test
{
    public static class ToggleHelper
    {
        public static IEnumerable<Toggle> ToggleList() =>
            new List<Toggle> {
                NewToggleConstructor(1, true, "1.0", 1, "Abc"),
                NewToggleConstructor(2, true, "1.0", 2, "Xyz"),
                NewToggleConstructor(3, true, "2.0")
            };

        public static Toggle NewToggleConstructor(int toggleId, bool enabled, string version, int? applicationId = null, string applicationName = null)
        {
            return new Toggle
            {
                Id = toggleId,
                ApplicationId = string.IsNullOrEmpty(applicationName) ? null : applicationId,
                Enable = enabled,
                Version = version,
                Application = applicationId.HasValue && !string.IsNullOrEmpty(applicationName) ? new Application() { Id = applicationId.Value, Name = applicationName } : null
            };
        }
    }
}