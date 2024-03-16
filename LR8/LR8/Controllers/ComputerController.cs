using LR8.Models;
using LR8.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LR8.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;

        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [HttpGet("computers/")]
        public async Task<IActionResult> GetComputers()
        {
            await Task.Delay(2000);
            var computers = await _computerService.GetComputersAsync();
            return Ok(computers);
        }

        [HttpGet("computers/{id}")]
        public async Task<IActionResult> GetComputerById(int id)
        {
            await Task.Delay(2000);
            var computer = await _computerService.GetComputerByIdAsync(id);
            if (computer == null)
                return NotFound($"Computer with ID {id} not found");
            return Ok(computer);
        }

        [HttpPost]
        public async Task<IActionResult> AddComputer([FromBody] Computer computer)
        {
            await Task.Delay(2000);
            await _computerService.AddComputerAsync(computer);
            return CreatedAtAction(nameof(GetComputers), new { id = computer.Id }, computer);
        }

        [HttpPut("computers/{id}")]
        public async Task<IActionResult> UpdateComputer(int id, [FromBody] Computer computer)
        {
            await Task.Delay(2000);
            var updatedComputer = await _computerService.UpdateComputerAsync(id, computer);
            if (updatedComputer == null)
                return NotFound($"Computer with ID {id} not found");
            return Ok($"Computer with ID {id} updated successfully");
        }

        [HttpDelete("computers/{id}")]
        public async Task<IActionResult> DeleteComputer(int id)
        {
            await Task.Delay(2000);
            var deletedComputer = await _computerService.DeleteComputerAsync(id);
            if (deletedComputer == null)
                return NotFound($"Computer with ID {id} not found");
            return Ok($"Computer with ID {id} deleted successfully");
        }
    }
}
