using System.Collections.Generic;
using ToggleApp.AppService.Dto;
using ToggleApp.Domain.Entities;

namespace ToggleApp.AppService.Tools
{
    public static class ToggleMapper
    {
        public static ToggleDto ToToggleDto(Toggle toggle)
        {
            return (toggle == null) ? null :
                new ToggleDto
                {
                    Name = toggle.Name,
                    Activated = toggle.Enable,
                    Version = toggle.Version
                };
        }

        public static Toggle ToToggle(ToggleDto toggleDto)
        {
            return (toggleDto == null) ? null :
                new Toggle
                {
                    Name = toggleDto.Name,
                    Enable = toggleDto.Activated,
                    Version = toggleDto.Version
                };
        }

        public static IEnumerable<Toggle> ToToggleList(IEnumerable<ToggleDto> togglesDto)
        {
            if (togglesDto == null)
            { 
                return null;
            }

            var toggleList = new List<Toggle>();
            
            foreach (var toggleDto in togglesDto)
            {
                toggleList.Add(ToToggle(toggleDto));
            }

            return toggleList;
        }

        public static IEnumerable<ToggleDto> ToToggleDtoList(IEnumerable<Toggle> toggles)
        {
            if (toggles == null)
            {
                return null;
            }

            var toggleDtoList = new List<ToggleDto>();
            foreach (var toggle in toggles)
            {
                toggleDtoList.Add(ToToggleDto(toggle));
            }

            return toggleDtoList;
        }
    }
}
