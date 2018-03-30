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
    public class ToggleServiceTest
    {
        private readonly Mock<IToggleService> _mocktoggleServices;
        private readonly Mock<IToggleRepository> _mockToggleRepository;
        private readonly ToggleService _mocktoggleService;

        public ToggleServiceTest()
        {
            _mocktoggleServices = new Mock<IToggleService>();
            _mockToggleRepository = new Mock<IToggleRepository>();
            _mocktoggleService = new ToggleService(_mockToggleRepository.Object);
        }

        [Fact]
        public async Task GetAllTogglesShouldReturnToggles()
        {
            _mockToggleRepository
                .Setup(m => m.GetAllAsync())
                .Returns(Task.FromResult(ToggleHelper.ToggleList()));

            var toggles = await _mocktoggleService.GetAllTogglesAsync();

            toggles.Should().NotBeNull();
        }

        [Fact]
        public void GetAllTogglesFromApplicationAsyncShouldReturnToggles()
        {
            _mockToggleRepository
                .Setup(m => m.GetByIdAsync(3))
                .Returns(Task.FromResult(ToggleHelper.ToggleList().First()));

            var toggle = _mocktoggleService.GetAllTogglesFromApplicationAsync(3, "2.0");

            toggle.Should().NotBeNull();
        }

        [Fact]
        public void GetToggleByIdAsyncShouldReturnToggle()
        {
            _mockToggleRepository
                .Setup(m => m.GetByIdAsync(1))
                .Returns(Task.FromResult(ToggleHelper.ToggleList().First()));

            var result = _mocktoggleService.GetToggleByIdAsync(1);

            result.Result.Should().NotBeNull();
        }

        [Fact]
        public void GetToggleByIdAsyncShouldBeNull()
        {
            _mockToggleRepository
                .Setup(m => m.GetByIdAsync(1))
                .Returns(Task.FromResult(ToggleHelper.ToggleList().First()));

            var result = _mocktoggleService.GetToggleByIdAsync(20);

            result.Result.Should().BeNull();
        }

        [Fact]
        public void AddToggleAsyncShouldCreateToggle()
        {
            _mockToggleRepository
                .Setup(m => m.GetByIdAsync(1))
                .Returns(Task.FromResult(ToggleHelper.ToggleList().First()));

            var toggle = _mocktoggleService.AddToggleAsync(ToggleHelper.ToggleList().Last());

            toggle.Should().NotBeNull();
        }

        [Fact]
        public void DeleteToggleAsyncShouldDeleteToggle()
        {
            _mockToggleRepository
                .Setup(m => m.GetByIdAsync(1))
                .Returns(Task.FromResult(ToggleHelper.ToggleList().First()));

            var toggle = _mocktoggleService.DeleteToggleAsync(ToggleHelper.ToggleList().Last());

            toggle.Should().NotBeNull();
        }

        [Fact]
        public void UpdateToggleAsyncShouldUpdateToggle()
        {
            _mockToggleRepository
                .Setup(m => m.GetByIdAsync(1))
                .Returns(Task.FromResult(ToggleHelper.ToggleList().First()));

            var toggle = _mocktoggleService.UpdateToggleAsync(ToggleHelper.ToggleList().First());

            toggle.Should().NotBeNull();
        }
    }
}
