using Gateway.API.DTOs.Identity;
using Gateway.API.DTOs.ParcelDelivery;
using Gateway.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gateway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelDeliveryController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly string _parcelDeliveryBaseUrl;

        public ParcelDeliveryController(IConfiguration config)
        {
            _config = config;
            _parcelDeliveryBaseUrl = _config["Microservices:ParcelDelivery"];
        }

        [HttpPost]
        public async Task<ActionResult<CreateParcelResponse>> CreateParcelAsync([FromBody] CreateParcelRequest request)
        {
            string url = $"{_parcelDeliveryBaseUrl}/parcel";
            var response = await HttpClientHelper.PostAsync<CreateParcelResponse>(url, JsonConvert.SerializeObject(request));
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateParcelResponse>> UpdateParcelAsync(string id, [FromBody] UpdateParcelRequest request)
        {
            request.Id = id;
            string url = $"{_parcelDeliveryBaseUrl}/parcel/{request.Id}";
            var response = await HttpClientHelper.PutAsync<UpdateParcelResponse>(url, JsonConvert.SerializeObject(request));
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetParcelsResponse>>> GetParcelsAsync()
        {
            string url = $"{_parcelDeliveryBaseUrl}/parcel";
            var response = await HttpClientHelper.GetAsync<List<GetParcelsResponse>>(url);
            return Ok(response);
        }

        [HttpGet("assignee")]
        public async Task<ActionResult<List<GetParcelsByAssigneeIdResponse>>> GetParcelsByAssigneeIdAsync([FromQuery] GetParcelsByAssigneeIdRequest request)
        {
            string url = $"{_parcelDeliveryBaseUrl}/parcel/assignee?assigneeId={request.AssigneeId}";
            var response = await HttpClientHelper.GetAsync<List<GetParcelsByAssigneeIdResponse>>(url);
            return Ok(response);
        }

        [HttpGet("author")]
        public async Task<ActionResult<List<GetParcelsByAuthorIdResponse>>> GetParcelsByAuthorIdAsync([FromQuery] GetParcelsByAuthorIdRequest request)
        {
            string url = $"{_parcelDeliveryBaseUrl}/parcel/author?authorId={request.AuthorId}";
            var response = await HttpClientHelper.GetAsync<List<GetParcelsByAuthorIdResponse>>(url);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetParcelByIdResponse>> GetParcelByIdAsync(string id)
        {
            var request = new GetParcelByIdRequest
            {
                Id = id
            };

            string url = $"{_parcelDeliveryBaseUrl}/parcel/{request.Id}";
            var response = await HttpClientHelper.GetAsync<GetParcelByIdResponse>(url);
            return Ok(response);
        }
    }
}