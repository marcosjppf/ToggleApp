using System.Collections.Generic;
using System.Threading.Tasks;
using ToggleApp.AppService.Dto;
using ToggleApp.AppService.Tools;
using ToggleApp.Domain.Repositories;

namespace ToggleApp.AppService.Implementations
{
    public class ToggleService : IToggleService
    {
        private readonly IToggleRepository _toggleRepository;

        public ToggleService(IToggleRepository toggleRepository)
        {
            _toggleRepository = toggleRepository;
        }

        public async Task<ToggleDto> GetToggleById(int id)
        {
            var toggle = await _toggleRepository.GetById(id);
            if (toggle == null)
                throw new KeyNotFoundException();

            return ToggleMapper.ToToggleDto(toggle);
        }

        public async Task<IEnumerable<ToggleDto>> GetAllToggles()
        {
            var toggles = await _toggleRepository.GetAll();
            if (toggles == null)
                throw new KeyNotFoundException();

            return ToggleMapper.ToToggleDtoList(toggles);
        }

        public async Task AddToggleAsync(ToggleDto toggleDto)
        {
            if (toggleDto == null)
                throw new TaskCanceledException();

            await _toggleRepository.AddAsync(ToggleMapper.ToToggle(toggleDto));
        }

        public async Task UpdateToggleAsync(ToggleDto toggleDto)
        {
            if (toggleDto == null)
                throw new TaskCanceledException();

            await _toggleRepository.UpdateAsync(ToggleMapper.ToToggle(toggleDto));
        }

        public async Task DeleteToggleAsync(int id)
        {
            var toggle = await _toggleRepository.GetById(id);
            if (toggle == null)
                throw new KeyNotFoundException();

            await _toggleRepository.DeleteAsync(toggle);
        }

        // Trazer todas as Toggles de uma determinada aplicação
    }
}
