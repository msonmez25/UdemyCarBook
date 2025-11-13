using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.VitesCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.VitesQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitesesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VitesesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> VitesList()
        {
            var values = await _mediator.Send(new GetVitesQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetVites(int id)
        {
            var value = await _mediator.Send(new GetVitesByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVites(CreateVitesCommand command)
        {
            await _mediator.Send(command);
            return Ok("Vites Türü Eklendi");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveVites(int id)
        {
            await _mediator.Send(new RemoveVitesCommand(id));
            return Ok("Vites Türü Silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateVites(UpdateVitesCommand command)
        {
            await _mediator.Send(command);
            return Ok("Vites Türü Güncellendi");
        }
    }
}
