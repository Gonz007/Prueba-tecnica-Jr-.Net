using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PruebaCheil.Aplication.Features.Delete
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeleteInfoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeleteInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleteInfoCommand = new DeleteInfoCommand
                {
                    HotelId = id
                };

                var result = await _mediator.Send(deleteInfoCommand);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el hotel: {ex.ToString()}");
                return StatusCode(500, $"Error al eliminar el hotel: {ex.Message}");
            }
        }
    }
}
