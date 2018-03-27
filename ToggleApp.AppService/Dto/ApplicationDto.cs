using System.Collections.Generic;

namespace ToggleApp.AppService.Dto
{
    public class ApplicationDto
    {
        public string Name { get; set; }

        public List<ToggleDto> Toggles { get; set; }
    }
}
