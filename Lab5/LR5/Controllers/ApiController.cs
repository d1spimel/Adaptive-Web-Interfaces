using LR5.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace LR5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        // HTTP CLIENT WRAPPER
        private readonly HttpClientWrapper _httpClientWrapper;

        // URL ARGUMENTS
        private readonly string _apiKey;
        private readonly string _speadsheetId;
        private readonly string _speadsheetName;
        private readonly string _speadsheetCell;
        private readonly string _accessToken; 

        public ApiController(HttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;

            _apiKey = "AIzaSyBENI5y39vdk5MRoixI9Jp9RAsISzB7S7U";
            _speadsheetId = "1VSpgY1D2w6fL3tXxM0lgj9rNwdKrYRGorDDCmhWyiOM";
            _speadsheetName = "Diamond%20Roulette";
            _speadsheetCell = "B1000";
            _accessToken = "ya29.a0AfB_byDVMxzZ5UwMiBcfZcKoJAWBl27SO218MEz_KFSygyuegGzdu19ZgiA6KoNeEuCfhlPhCt0mH-sVu80_7VZrT1H8XOApgcWPHkNHCqReqlfDA1X3jt2P5haC7EmJaQHLR_zYCiwTp-igYFV2CR1vppxMO10NYdKhzzwaCgYKAXASARMSFQ";
        }

        // GET REQUEST
        [HttpGet]
        public async Task<IActionResult> GetResultAsync()
        {
            var response = new ApiResponse<string>();

            try
            {
                string responseData = await _httpClientWrapper.GetAsync($"https://sheets.googleapis.com/v4/spreadsheets/{_speadsheetId}/values/{_speadsheetName}!{_speadsheetCell}?key={_apiKey}");

                response.Data = new List<string> { responseData };
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "GET Request to Google Sheets API!";
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }

            return StatusCode((int)response.StatusCode, response);
        }

        // POST REQUEST
        [HttpPost]
        public async Task<IActionResult> PostResultAsync([FromBody] GoogleSheetsEditResponse request)
        {
            var response = new ApiResponse<string>();

            try
            {
                var jsonData = JsonConvert.SerializeObject(request);
                string responseData = await _httpClientWrapper.PostAsync($"https://sheets.googleapis.com/v4/spreadsheets/{_speadsheetId}:batchUpdate?access_token={_accessToken}" , request);
                response.Data = new List<string> { responseData };
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "POST Request to Google Sheets API!";
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }

            return StatusCode((int)response.StatusCode, response);
        }
    }
}