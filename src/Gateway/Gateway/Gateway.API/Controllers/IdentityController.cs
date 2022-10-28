using Gateway.API.DTOs.Identity;
using Gateway.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gateway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly string _identityBaseUrl;

        public IdentityController(IConfiguration config)
        {
            _config = config;
            _identityBaseUrl = _config["Microservices:Identity"];
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            string url = $"{_identityBaseUrl}/account/login";
            var response = await HttpClientHelper.PostAsync<LoginResponse>(url, JsonConvert.SerializeObject(request));
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> RegisterAsync([FromBody] RegisterRequest request)
        {
            string url = $"{_identityBaseUrl}/account/register";
            var response = await HttpClientHelper.PostAsync<LoginResponse>(url, JsonConvert.SerializeObject(request));
            return Ok(response);
        }

        [HttpGet("couriers")]
        public async Task<ActionResult<List<GetAllCourierUsersResponse>>> GetAllCourierUsersAsync()
        {
            string url = $"{_identityBaseUrl}/account/couriers";
            var response = await HttpClientHelper.GetAsync<List<GetAllCourierUsersResponse>>(url);
            return Ok(response);
        }
    }
}