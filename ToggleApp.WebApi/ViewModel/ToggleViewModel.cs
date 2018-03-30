namespace ToggleApp.WebApi.Model
{
    public class ToggleViewModel
    {
        public ToggleViewModel(string name, bool value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public bool Value { get; set; }
    }
}
