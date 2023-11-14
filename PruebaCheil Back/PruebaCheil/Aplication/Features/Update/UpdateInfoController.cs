using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaCheil.Aplication.Features.Update;
using System;
using System.Threading.Tasks;

namespace PruebaCheil.Aplication.Features.Update
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateInfoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Actualiza la información de un hotel.
        /// </summary>
        /// <param name="id">ID del hotel a actualizar</param>
        /// <param name="updateInfoDto">DTO con la información actualizada</param>
        /// <returns>Resultado de la actualización</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateInfoDto updateInfoDto)
        {
            try
            {
                var updateInfoCommand = new UpdateInfoCommand
                {
                    HotelId = id,
                    UpdateInfoDto = updateInfoDto
                };

                var result = await _mediator.Send(updateInfoCommand);

                if (result.UpdatedHotelId > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound($"No se encontró el hotel con el ID {id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
            }
        }
    }
}
