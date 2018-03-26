using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToggleApp.Domain.Entities;

namespace ToggleApp.Data.Configurations
{
    public class ApplicationEntityConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> applicationConfiguration)
        {


        }
    }
}
