using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParcelDelivery.Logic.Features.Parcels.Commands.CreateParcel;
using ParcelDelivery.Logic.Features.Parcels.Commands.UpdateParcel;
using ParcelDelivery.Logic.Features.Parcels.Queries.GetParcelById;
using ParcelDelivery.Logic.Features.Parcels.Queries.GetParcels;
using ParcelDelivery.Logic.Features.Parcels.Queries.GetParcelsByAssigneeId;
using ParcelDelivery.Logic.Features.Parcels.Queries.GetParcelsByAuthorId;

namespace ParcelDelivery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParcelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateParcelCommandResponse>> CreateParcelAsync([FromBody] CreateParcelCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateParcelCommandResponse>> UpdateParcelAsync(string id, [FromBody] UpdateParcelCommand request)
        {
            request.Id = id;
            return Ok(await _mediator.Send(request));
        }

        [HttpGet]
        public async Task<ActionResult<List<GetParcelsQueryResponse>>> GetParcelsAsync()
        {
            return Ok(await _mediator.Send(new GetParcelsQuery()));
        }

        [HttpGet("assignee")]
        public async Task<ActionResult<List<GetParcelsByAssigneeIdQueryResponse>>> GetParcelsByAssigneeIdAsync([FromQuery] GetParcelsByAssigneeIdQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("author")]
        public async Task<ActionResult<List<GetParcelsByAuthorIdQueryResponse>>> GetParcelsByAuthorIdAsync([FromQuery] GetParcelsByAuthorIdQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetParcelByIdQueryResponse>> GetParcelByIdAsync(string id)
        {
            var request = new GetParcelByIdQuery
            {
                Id = id
            };

            return Ok(await _mediator.Send(request));
        }
    }
}