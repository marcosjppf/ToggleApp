using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToggleApp.AppService.Interfaces;
using ToggleApp.Domain.Entities;
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

        /// <summary>
        /// Get All Toggles.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Toggles
        ///
        /// </remarks>
        /// <returns>All existing Toggles</returns>
        /// <response code="200">Success Message</response>
        /// <response code="400">If the list of Toggles is null</response>      
        [HttpGet]
        public async Task<IEnumerable<ToggleViewModel>> Get()
        {
            var toggles = await _toggleServices.GetAllTogglesAsync();
            var toggleModelList = new List<ToggleViewModel>();

            if (toggles == null)
                return toggleModelList;

            foreach (var toggle in toggles)
                toggleModelList.Add(new ToggleViewModel(toggle.Name, toggle.Enable));

            return toggleModelList;
        }

        /// <summary>
        /// Get All Toggles.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Toggles/{id}
        ///
        /// </remarks>
        /// <returns>All existing Toggles</returns>
        /// <response code="200">Success Message</response>
        /// <response code="400">If the list of Toggles is null</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
                return BadRequest($"Invalid parameters");

            var toggle = await _toggleServices.GetToggleByIdAsync(id);

            if (toggle == null)
                return NotFound($"Toggle id {id} not found");

            return new ObjectResult(new ToggleViewModel(toggle.Name, toggle.Enable));
        }

        /// <summary>
        /// Get All Toggles.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Toggles/{applicationId}/{version}
        ///
        /// </remarks>
        /// <param name="applicationId">Application/Service Id</param>
        /// <param name="version">Toggle version</param>
        /// <returns>A list of Toggle from Application/Service</returns>
        /// <response code="200">Success Message</response>
        /// <response code="400">Bad Request</response>      
        /// <response code="404">Not Found the Toggle</response> 
        [HttpGet("{applicationId}/{version}")]
        public async Task<IActionResult> Get(int applicationId, string version)
        {
            if (applicationId <= 0 || string.IsNullOrWhiteSpace(version))
                return BadRequest($"Invalid parameters");

            var application = _applicationServices.GetApplicationByIdAsync(applicationId);

            if (await _applicationServices.GetApplicationByIdAsync(applicationId) == null)
                return NotFound($"ApplicationId {applicationId} does not exists.");

            var toggles = _toggleServices.GetAllTogglesFromApplicationAsync(applicationId, version);
            var toggleModelList = new List<ToggleViewModel>();

            foreach (var toggle in toggles)
                toggleModelList.Add(new ToggleViewModel(toggle.Name, toggle.Enable));

            if (toggleModelList.Count.Equals(0))
                return NotFound($"toggles in this version \"{version}\" does not exists.");

            return new ObjectResult(toggleModelList);
        }

        /// <summary>
        /// Creates a Toggle.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Toggle/{applicationId}/{version}
        ///     {
        ///        "name": "isButtonNew",
        ///        "value": true
        ///     }
        ///
        /// </remarks>
        /// <param name="applicationId">Application/Service Id</param>
        /// <param name="version">Toggle version</param>
        /// <param name="toggleViewModel">Toggle model</param>
        /// <returns>Success Message</returns>
        /// <response code="201">Created Message</response>
        /// <response code="400">Bad Request</response>      
        /// <response code="404">Not Found the Toggle</response> 
        [HttpPost("{applicationId}/{version}")]
        public async Task<IActionResult> Post(int applicationId, string version, [FromBody]ToggleViewModel toggleViewModel)
        {
            try
            {
                if (applicationId <= 0 || string.IsNullOrWhiteSpace(version) || toggleViewModel == null)
                    return BadRequest($"Invalid parameters");

                if (await _applicationServices.GetApplicationByIdAsync(applicationId) == null)
                    return NotFound($"ApplicationId {applicationId} does not exists.");

                var toggleSaved = await _toggleServices
                    .AddToggleAsync(new Toggle
                    {
                        ApplicationId = applicationId,
                        Version = version,
                        Name = toggleViewModel.Name,
                        Enable = toggleViewModel.Value
                    });

                return Ok($"New Toggle registered. id = { toggleSaved.Id }");
            }
            catch (Exception)
            {
                return NotFound($"Error: New Toggle {toggleViewModel.Name} not registered");
            }
        }

        /// <summary>
        /// Updates a Toggle.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Toggle/{id}
        ///     {
        ///        "name": "isButtonNew",
        ///        "value": true
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Toggle Id</param>
        /// <param name="toggleViewModel">Toggle model</param>
        /// <returns>Success Message</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>      
        /// <response code="404">Not Found the Toggle</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ToggleViewModel toggleViewModel)
        {
            try
            {
                if (id <= 0 || toggleViewModel == null)
                    return BadRequest();

                var toggle = await _toggleServices.GetToggleByIdAsync(id);

                if (toggle == null)
                    return NotFound($"Toggle Id {id} does not exists.");

                toggle.Enable = toggleViewModel.Value;
                toggle.Name = toggleViewModel.Name;

                var toggleUpdated = await _toggleServices.UpdateToggleAsync(toggle);

                return Ok($"Toggle Updated. id = { toggleUpdated.Id }");
            }
            catch (Exception)
            {
                return NotFound($"Toggle {id} does not exist");
            }
        }

        /// <summary>
        /// Deletes a Toggle.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /Toggle/{id}
        ///
        /// </remarks>
        /// <param name="id">Toggle Id</param>
        /// <returns>Success Message</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>      
        /// <response code="404">Not Found the Toggle</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                var toggle = await _toggleServices.GetToggleByIdAsync(id);

                if (toggle == null)
                    return NotFound($"Toggle Id {id} does not exists.");

                await _toggleServices.DeleteToggleAsync(toggle);

                return Ok($"Toggle { toggle.Id } deleted");
            }
            catch (Exception)
            {
                return NotFound($"Toggle {id} does not exist");
            }
        }
    }
}
