using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaCheil.Aplication.Features.Create;
using PruebaCheil.Aplication.Features.Get;
using System.Threading.Tasks;

namespace PruebaCheil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateInfoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInfoDto createInfoDto)
        {
            try
            {
                var createInfoCommand = new CreateInfoCommand
                {
                    CreateInfoDto = createInfoDto
                };

                var result = await _mediator.Send(createInfoCommand);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el hotel: {ex.ToString()}");

                return StatusCode(500, $"Error al crear el hotel: {ex.Message}");
            }
        }



    }
}
