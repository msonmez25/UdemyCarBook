using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.YakitTuruCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.YakitTuruQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YakitTurusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public YakitTurusController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> YakitTuruList()
        {
            var values = await _mediator.Send(new GetYakitTuruQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetYakitTuru(int id)
        {
            var value = await _mediator.Send(new GetYakitTuruByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateYakitTuru(CreateYakitTuruCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yakıt Türü Eklendi");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveYakitTuru(int id)
        {
            await _mediator.Send(new RemoveYakitTuruCommand(id));
            return Ok("Yakıt Türü Silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateYakitTuru(UpdateYakitTuruCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yakıt Türü Güncellendi");
        }
    }
}
