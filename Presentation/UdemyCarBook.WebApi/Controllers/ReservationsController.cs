using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureDetailCommands;
using UdemyCarBook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.ReservationQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> ReservationList()
        {
            var values = await _mediator.Send(new GetReservationQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(int id)
        {
            var value = await _mediator.Send(new GetReservationByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rezervasyon Eklendi");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveReservation(int id)
        {
            await _mediator.Send(new RemoveReservationCommand(id));
            return Ok("Rezervasyon Silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateReservation(UpdateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rezervasyon Güncellendi");
        }


        [HttpGet("ChangeReservationStatusToApproved")]
        public async Task<IActionResult> ChangeReservationStatusToApproved(int id)
        {
            await _mediator.Send(new ChangeReservationStatusToApprovedCommand(id));
            return Ok("Rezervasyon onaylandı.");
        }

        [HttpGet("ChangeReservationStatusToCancaled")]
        public async Task<IActionResult> ChangeReservationStatusToCancaled(int id)
        {
            await _mediator.Send(new ChangeReservationStatusToCancaledCommand(id));
            return Ok("Rezervasyon iptal edildi.");
        }

        [HttpGet("ChangeReservationStatusToReservationReceipt")]
        public async Task<IActionResult> ChangeReservationStatusToReservationReceipt(int id)
        {
            await _mediator.Send(new ChangeReservationStatusToReservationReceiptCommand(id));
            return Ok("Rezervasyon alındı.");
        }
    }
}
