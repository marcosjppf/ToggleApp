using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToggleApp.AppService.Interfaces;
using ToggleApp.Domain.Entities;
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

        public async Task<Toggle> GetToggleByIdAsync(int id)
        {
            return await _toggleRepository.GetByIdAsync(id);
        }

        public IEnumerable<Toggle> GetAllTogglesFromApplicationAsync(int applicationId, string version)
        {
            return _toggleRepository.GetFromApplication(applicationId, version);
        }

        public async Task<IEnumerable<Toggle>> GetAllTogglesAsync()
        {
            return await _toggleRepository.GetAllAsync();
        }

        public async Task<Toggle> AddToggleAsync(Toggle toggle)
        {
            if (toggle == null)
                throw new NullReferenceException();

            return await _toggleRepository.AddAsync(toggle);
        }

        public async Task DeleteToggleAsync(Toggle toggle)
        {
            if (toggle == null)
                throw new NullReferenceException();

            await _toggleRepository.DeleteAsync(toggle);
        }

        public async Task<Toggle> UpdateToggleAsync(Toggle toggle)
        {
            if (toggle == null)
                throw new NullReferenceException();

            return await _toggleRepository.UpdateAsync(toggle);
        }
    }
}
