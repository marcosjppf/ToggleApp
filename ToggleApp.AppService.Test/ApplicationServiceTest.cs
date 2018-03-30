using Moq;
using System.Threading.Tasks;
using ToggleApp.AppService.Implementations;
using ToggleApp.AppService.Interfaces;
using FluentAssertions;
using ToggleApp.Domain.Repositories;
using Xunit;
using System.Linq;

namespace ToggleApp.AppService.Test
{
    public class ApplicationServiceTest
    {
        private readonly Mock<IApplicationService> _mockApplicationServices;
        private readonly Mock<IApplicationRepository> _mockApplicationRepository;
        private readonly ApplicationService _mockApplicationService;

        public ApplicationServiceTest()
        {
            _mockApplicationServices = new Mock<IApplicationService>();
            _mockApplicationRepository = new Mock<IApplicationRepository>();
            _mockApplicationService = new ApplicationService(_mockApplicationRepository.Object);
        }

        [Fact]
        public void GetApplicationByIdShouldReturnApplication()
        {
            _mockApplicationRepository
                .Setup(m => m.GetAllAsync())
                .Returns(Task.FromResult(ApplicationHelper.ToggleList()));

            var result = _mockApplicationService.GetApplicationByIdAsync(2);

            result.Should().NotBeNull();
        }

        [Fact]
        public void GetApplicationByIdShouldReturnNull()
        {
            _mockApplicationRepository
                .Setup(m => m.GetAllAsync())
                .Returns(Task.FromResult(ApplicationHelper.ToggleList()));

            var result = _mockApplicationService.GetApplicationByIdAsync(20);

            result.Result.Should().BeNull();
        }
    }
}
