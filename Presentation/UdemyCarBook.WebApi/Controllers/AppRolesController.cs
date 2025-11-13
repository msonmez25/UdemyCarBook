using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.AppRoleCommands;
using UdemyCarBook.Application.Features.Mediator.Commands.VitesCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.AppRoleQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.VitesQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppRolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppRolesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> AppRoleList()
        {
            var values = await _mediator.Send(new GetAppRoleQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppRole(int id)
        {
            var value = await _mediator.Send(new GetAppRoleByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppRole(CreateAppRoleCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rol Türü Eklendi");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveAppRole(int id)
        {
            await _mediator.Send(new RemoveAppRoleCommand(id));
            return Ok("Rol Türü Silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAppRole(UpdateAppRoleCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rol Türü Güncellendi");
        }
    }
}
