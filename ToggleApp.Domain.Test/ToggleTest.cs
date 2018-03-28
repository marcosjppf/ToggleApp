using Xunit;
using ToggleApp.Domain.Entities;
using FluentAssertions;

namespace ToggleApp.Domain.Test
{
    public class ToggleTest
    {
        #region Constants
        const int pilatesApplicationId = 1;
        const int bankApplicationId = 2;
        const int ecommerceApplicationId = 3;
        const string version = "1.000"; 
        #endregion

        #region private methods
        private int[] ToggleIds()
            => new int[] { 1, 2 };

        private static Toggle NewToggleConstructor(int toggleId, bool enabled, int? applicationId = null)
        {
            //Toggle named isButtonBlue with value true can be used by all services.
            return new Toggle
            {
                Id = toggleId,
                ApplicationId = applicationId,
                Enable = enabled,
                Version = version,
                Application = applicationId.HasValue ? GetApplication(applicationId.Value) : null
            };
        }

        private static Application GetApplication(int id)
        {
            return new Application
            {
                Id = id,
                Name = id.ToString()
            };
        }
        #endregion

        [Fact]
        public void ToggleAcessibleTo()
        {
            var toggleIds = ToggleIds();
            var toggleA = NewToggleConstructor(toggleIds[0], false, pilatesApplicationId);
            var toggleB = NewToggleConstructor(toggleIds[1], true, bankApplicationId);

            //Assert
            toggleA.AcessibleTo(pilatesApplicationId, version).Should().BeTrue();
            toggleA.AcessibleTo(bankApplicationId, version).Should().BeFalse();
            toggleB.AcessibleTo(ecommerceApplicationId, version).Should().BeFalse();
        }

        [Fact]
        public void ToggleIsPublic()
        {
            var toggleIds = ToggleIds();
            var toggleA = NewToggleConstructor(toggleIds[0], false, pilatesApplicationId);
            var toggleB = NewToggleConstructor(toggleIds[1], true);

            //Assert
            toggleA.IsPublic.Should().BeFalse();
            toggleB.IsPublic.Should().BeTrue();
        }
    }
}
