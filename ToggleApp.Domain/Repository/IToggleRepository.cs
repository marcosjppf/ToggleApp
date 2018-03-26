using System.Collections.Generic;
using ToggleApp.Domain.Entities;

namespace ToggleApp.Domain.Repository
{
    public interface IToggleRepository
    {
        void Add(Toggle toggle);
        IEnumerable<Toggle> Get();
        Toggle Get(int id);
    }
}
