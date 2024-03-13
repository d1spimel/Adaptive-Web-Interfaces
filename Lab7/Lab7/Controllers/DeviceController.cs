using Lab7.Models;
using Lab7.Services;
using Lab7.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet("devices/")]
        public async Task<IActionResult> GetDevices()
        {
            await Task.Delay(2000);
            var devices = await _deviceService.GetDevicesAsync();
            return Ok(devices);
        }

        [HttpGet("devices/{id}")]
        public async Task<IActionResult> GetDeviceById(int id)
        {
            await Task.Delay(2000);
            var device = await _deviceService.GetDeviceByIdAsync(id);
            if (device == null)
                return NotFound($"Device with ID {id} not found");
            return Ok(device);
        }

        [HttpPost]
        public async Task<IActionResult> AddDevice([FromBody] Device device)
        {
            await Task.Delay(2000);
            await _deviceService.AddDeviceAsync(device);
            return CreatedAtAction(nameof(GetDevices), new { id = device.Id }, device);
        }

        [HttpPut("devices/{id}")]
        public async Task<IActionResult> UpdateDevice(int id, [FromBody] Device device)
        {
            await Task.Delay(2000);
            var updatedDevice = await _deviceService.UpdateDeviceAsync(id, device);
            if (updatedDevice == null)
                return NotFound($"Device with ID {id} not found");
            return Ok($"Device with ID {id} updated successfully");
        }

        [HttpDelete("devices/{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            await Task.Delay(2000);
            var deletedDevice = await _deviceService.DeleteDeviceAsync(id);
            if (deletedDevice == null)
                return NotFound($"Device with ID {id} not found");
            return Ok($"Device with ID {id} deleted successfully");
        }
    }
}
