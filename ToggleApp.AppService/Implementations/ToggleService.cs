using System;
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

        public async Task<ToggleDto> GetToggleByIdAsync(int id)
        {
            var toggle = await _toggleRepository.GetByIdAsync(id);
            return ToggleMapper.ToToggleDto(toggle);
        }

        public IEnumerable<ToggleDto> GetAllTogglesFromApplicationAsync(int applicationId, string version)
        {
            return ToggleMapper.ToToggleDtoList(_toggleRepository.GetFromApplication(applicationId, version));
        }

        public async Task<IEnumerable<ToggleDto>> GetAllTogglesAsync()
        {
            var toggles = await _toggleRepository.GetAllAsync();
            return ToggleMapper.ToToggleDtoList(toggles);
        }

        public async Task AddToggleAsync(ToggleDto toggleDto)
        {
            if (toggleDto == null)
                throw new NullReferenceException();

            await _toggleRepository.AddAsync(ToggleMapper.ToToggle(toggleDto));
        }

        public async Task UpdateToggleAsync(ToggleDto toggleDto)
        {
            if (toggleDto == null)
                throw new NullReferenceException();

            if (await _toggleRepository.GetByIdAsync(toggleDto.Id) == null)
                throw new KeyNotFoundException();

            await _toggleRepository.UpdateAsync(ToggleMapper.ToToggle(toggleDto));
        }

        public async Task DeleteToggleAsync(int id)
        {
            var toggle = await _toggleRepository.GetByIdAsync(id);
            if (toggle == null)
                throw new KeyNotFoundException();

            await _toggleRepository.DeleteAsync(toggle);
        }
    }
}
