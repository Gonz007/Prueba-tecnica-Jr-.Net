using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaCheil.Aplication.Features.Get;
using System.Threading.Tasks;

namespace PruebaCheil.Aplication.Features.Get
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetInfoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Consulta con filtros.
        /// </summary>
        /// <param name="getInfoDto">DTO con filtros de consulta</param>
        /// <returns>Resultado de la consulta</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get([FromQuery] GetInfoDto getInfoDto)
        {
            try
            {
                GetInfoQuery query = new GetInfoQuery(getInfoDto);
                var result = await _mediator.Send(query);

                if (result != null && result.GetInfoDetail.Count > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
