using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.RentACarCommands;
using UdemyCarBook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarBook.Application.Features.Mediator.Commands.VitesCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.CommentQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.PricingQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetRentACarByLocation(int locationID,bool available)
        {
            GetRentACarQuery getRentACarQuery = new GetRentACarQuery()
            {
                LocationID = locationID,
                Avaible = available
            };
            var values = await _mediator.Send(getRentACarQuery);
            return Ok(values);
        }


        [HttpGet("GetRentACarById")]
        public async Task<IActionResult> GetRentACarById(int id)
        {
            var value = await _mediator.Send(new GetRentACarByIdQuery(id));
            return Ok(value);
        }


        [HttpGet("GetRentACarByCarNameLocationName")]
        public async Task<IActionResult> GetRentACarByCarNameLocationName()
        {
            var values = await _mediator.Send(new GetRentACarByCarNameLocationNameQuery());
            return Ok(values);
        }




        [HttpPost]
        public async Task<IActionResult> CreateRentACar(CreateRentACarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Uygun Kiralık Araç Eklendi");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveRentACar(int id)
        {
            await _mediator.Send(new RemoveRentACarCommand(id));
            return Ok("Uygun Kiralık Araç Silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateRentACar(UpdateRentACarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Uygun Kiralık Araç Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentACarByIdQuery(int id)
        {
            var value = await _mediator.Send(new GetRentACarByIdQuery(id));
            return Ok(value);
        }


        [HttpGet("ChangeRentACarAvaibleToFalse")]
        public async Task<IActionResult> ChangeRentACarAvaibleToFalse(int id)
        {
            await _mediator.Send(new ChangeRentACarAvaibleToFalseCommand(id));
            return Ok("Kiralık Araç müsait değil olarak güncellendi.");
        }


        [HttpGet("ChangeRentACarAvaibleToTrue")]
        public async Task<IActionResult> ChangeRentACarAvaibleToTrue(int id)
        {
            await _mediator.Send(new ChangeRentACarAvaibleToTrueCommand(id));
            return Ok("Kiralık Araç müsait olarak güncellendi.");
        }
    }
}

