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

        public Toggle GetToggleById(int id)
        {
            var toggle = _toggleRepository.GetById(id);
            if (toggle == null)
                throw new KeyNotFoundException();

            return toggle;
        }

        public IEnumerable<Toggle> GetAllToggles()
        {
            return _toggleRepository.GetAll();
        }

        public async Task AddToggleAsync(Toggle toggle)
        {
            await _toggleRepository.AddAsync(toggle);
        }

        public async Task UpdateToggleAsync(Toggle toggle)
        {
            await _toggleRepository.UpdateAsync(toggle);
        }

        public async Task DeleteToggleAsync(int id)
        {
            var toggle = _toggleRepository.GetById(id);
            if (toggle == null)
                throw new KeyNotFoundException();

            await _toggleRepository.DeleteAsync(toggle);
        }
    }
}
