using System.Collections.Generic;
using System.Linq;
using ToggleApp.Data.Context;
using ToggleApp.Domain.Entities;
using ToggleApp.Domain.Repository;

namespace ToggleApp.Data.Repository
{
    public class ToggleRepository : IToggleRepository
    {
        private readonly ToggleAppDbContext _toggleAppDbContext;

        public ToggleRepository(ToggleAppDbContext webAppDbContext)
        {
            _toggleAppDbContext = webAppDbContext;
        }

        public void Add(Toggle toggle)
        {
            _toggleAppDbContext.Add(toggle);
            _toggleAppDbContext.SaveChanges();
        }

        public IEnumerable<Toggle> Get()
        {
            return _toggleAppDbContext.Toggles.ToList();
        }

        public Toggle Get(int id)
        {
            return _toggleAppDbContext.Toggles.FirstOrDefault(tog => tog.Id == id);
        }
    }
}
