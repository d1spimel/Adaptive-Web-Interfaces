using Lab7.Models;
using Lab7.Services;
using Lab7.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComputerComponentController : ControllerBase
    {
        private readonly IComputerComponentService _computerComponentService;

        public ComputerComponentController(IComputerComponentService computerComponentService)
        {
            _computerComponentService = computerComponentService;
        }

        [HttpGet("components/")]
        public async Task<IActionResult> GetComputerComponents()
        {
            await Task.Delay(2000);
            var components = await _computerComponentService.GetComputerComponentsAsync();
            return Ok(components);
        }

        [HttpGet("components/{id}")]
        public async Task<IActionResult> GetComputerComponentById(int id)
        {
            await Task.Delay(2000);
            var component = await _computerComponentService.GetComputerComponentByIdAsync(id);
            if (component == null)
                return NotFound($"Computer Component with ID {id} not found");
            return Ok(component);
        }

        [HttpPost]
        public async Task<IActionResult> AddComputerComponent([FromBody] ComputerComponent component)
        {
            await Task.Delay(2000);
            await _computerComponentService.AddComputerComponentAsync(component);
            return CreatedAtAction(nameof(GetComputerComponents), new { id = component.Id }, component);
        }

        [HttpPut("components/{id}")]
        public async Task<IActionResult> UpdateComputerComponent(int id, [FromBody] ComputerComponent component)
        {
            await Task.Delay(2000);
            var updatedComponent = await _computerComponentService.UpdateComputerComponentAsync(id, component);
            if (updatedComponent == null)
                return NotFound($"Computer Component with ID {id} not found");
            return Ok($"Computer Component with ID {id} updated successfully");
        }

        [HttpDelete("components/{id}")]
        public async Task<IActionResult> DeleteComputerComponent(int id)
        {
            await Task.Delay(2000);
            var deletedComponent = await _computerComponentService.DeleteComputerComponentAsync(id);
            if (deletedComponent == null)
                return NotFound($"Computer Component with ID {id} not found");
            return Ok($"Computer Component with ID {id} deleted successfully");
        }
    }
}
