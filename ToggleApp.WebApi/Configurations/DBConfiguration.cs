using System.Collections.Generic;
using System.Linq;
using ToggleApp.Data.Context;
using ToggleApp.Domain.Entities;

namespace ToggleApp.WebApi.Configurations
{
    internal static class DBConfiguration
    {
        internal static void CreateDbData(ToggleAppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Applications.Any())
                return;

            var applications = new List<Application>
            {
                new Application { Name = "Abc" },
                new Application { Name = "Xyz" }
            };

            applications.ForEach(a => context.Applications.Add(a));
            context.SaveChanges();

            var toggles = new List<Toggle>
            {
                new Toggle { Name = "isButtonBlue", Enable = true },
                new Toggle { Name = "isButtonBlue", Enable = false, Application = applications[0], Version = "1.0" },
                new Toggle { Name = "isButtonGreen", Enable = true, Application = applications[0], Version = "1.0" },
                new Toggle { Name = "isButtonRed", Enable = true, Application = applications[1], Version = "1.0" }
            };

            toggles.ForEach(t => context.Toggles.Add(t));
            context.SaveChanges();
        }
    }
}
