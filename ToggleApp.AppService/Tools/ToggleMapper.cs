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
                    Id = toggle.Id,
                    Name = toggle.Name,
                    Activated = toggle.Enable,
                    Version = toggle.Version,
                    ApplicationId = toggle.ApplicationId.HasValue ? toggle.ApplicationId.Value : (int?)null
                };
        }

        public static Toggle ToToggle(ToggleDto toggleDto)
        {
            return (toggleDto == null) ? null :
                new Toggle
                {
                    Id = toggleDto.Id,
                    Name = toggleDto.Name,
                    Enable = toggleDto.Activated,
                    Version = toggleDto.Version,
                    ApplicationId = toggleDto.ApplicationId > 0 ? toggleDto.ApplicationId : (int?)null
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
