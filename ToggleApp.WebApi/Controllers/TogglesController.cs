﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToggleApp.AppService.Dto;
using ToggleApp.AppService.Implementations;
using ToggleApp.WebApi.Model;

namespace ToggleApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TogglesController : Controller
    {
        private readonly IToggleService _toggleServices;
        private readonly IApplicationService _applicationServices;

        public TogglesController(IToggleService toggleServices, IApplicationService applicationServices)
        {
            _toggleServices = toggleServices;
            _applicationServices = applicationServices;
        }

        [HttpGet]
        public async Task<IEnumerable<ToggleModel>> Get()
        {
            var toggles = await _toggleServices.GetAllTogglesAsync();
            var toggleModelList = new List<ToggleModel>();

            if (toggles == null)
                return toggleModelList;
            
            foreach (var toggle in toggles)
                toggleModelList.Add(new ToggleModel(toggle.Name, toggle.Activated));

            return toggleModelList;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var toggle = await _toggleServices.GetToggleByIdAsync(id);

            if (toggle == null)
                return NotFound($"Toggle id {id} not found");

            return new ObjectResult(new ToggleModel(toggle.Name, toggle.Activated));
        }

        [HttpGet("{applicationId}/{version}")]
        public async Task<IActionResult> Get(int applicationId, string version)
        {
            if (await _applicationServices.GetApplicationByIdAsync(applicationId) == null)
                return NotFound($"ApplicationId {applicationId} does not exists.");

            var toggles = _toggleServices.GetAllTogglesFromApplicationAsync(applicationId, version);
            var toggleModelList = new List<ToggleModel>();

            foreach (var toggle in toggles)
                toggleModelList.Add(new ToggleModel(toggle.Name, toggle.Activated));

            if (toggleModelList.Count.Equals(0))
                return NotFound($"toggles in this version \"{version}\" does not exists.");

            return new ObjectResult(toggleModelList);
        }

        [HttpPost("{applicationId}/{version}")]
        public async Task<IActionResult> Post(int applicationId, string version, [FromBody]ToggleModel model)
        {
            try
            {
                if (await _applicationServices.GetApplicationByIdAsync(applicationId) == null)
                    return NotFound($"ApplicationId {applicationId} does not exists.");

                await _toggleServices.AddToggleAsync(new ToggleDto { ApplicationId = applicationId, Version = version, Name = model.Name, Activated = model.Value });
                return Ok($"New Toggle with {model.Name} registered");
            }
            catch (Exception)
            {
                return NotFound($"Error: New Toggle {model.Name} not registered");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ToggleModel model)
        {
            try
            {
                await _toggleServices.UpdateToggleAsync(new ToggleDto
                {
                    Id = id,
                    Name = model.Name,
                    Activated = model.Value
                });
                return new NoContentResult();
            }
            catch (Exception)
            {
                return NotFound($"Toggle {id} does not exist");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _toggleServices.DeleteToggleAsync(id);
                return new NoContentResult();
            }
            catch (Exception)
            {
                return NotFound($"Toggle {id} does not exist");
            }
        }
    }
}
