using System.Collections.Generic;

namespace ToggleApp.Domain.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Toggle> Toggles { get; set; }
    }
}
    