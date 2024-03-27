using LR8.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LR8.Controllers
{
    public class VersionController
    {
        [ApiController]
        [Route("api/v{version:apiVersion}/[controller]/[action]")]
        [ApiVersion("1.0", Deprecated = true)]
        [ApiVersion("2.0")]
        [ApiVersion("3.0")]
        public class VersionedController : ControllerBase
        {
            private readonly IVersionService _versionService;

            public VersionedController(IVersionService versionService)
            {
                _versionService = versionService;
            }

            [HttpGet("/firstVersion")]
            [MapToApiVersion("1.0")]
            [Authorize]
            public IActionResult GetFirstVersion()
            {
                int result = _versionService.GetFirstVersion();
                return Ok(result);
            }

            [HttpGet("/secondVersion")]
            [MapToApiVersion("2.0")]
            public IActionResult GetSecondVersion()
            {
                string result = _versionService.GetSecondVersion();
                return Ok(result);
            }

            [HttpGet("/thirdVersion")]
            [MapToApiVersion("3.0")]
            public IActionResult GetThirdVersion()
            {
                byte[] excelFile = _versionService.GetThirdVersion();
                return File(excelFile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "APIVersion.xlsx");
            }
        }
    }
}