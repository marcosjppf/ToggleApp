using System.ComponentModel.DataAnnotations;

namespace ToggleApp.WebApi.Model
{
    public class ToggleViewModel
    {
        public ToggleViewModel(string name, bool value)
        {
            Name = name;
            Value = value;
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public bool Value { get; set; }
    }
}
