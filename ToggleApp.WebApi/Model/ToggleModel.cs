using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToggleApp.WebApi.Model
{
    public class ToggleModel
    {
        public ToggleModel(string name, bool value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public bool Value { get; set; }
    }
}
