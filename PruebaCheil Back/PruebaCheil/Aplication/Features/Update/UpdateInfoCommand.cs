using MediatR;

namespace PruebaCheil.Aplication.Features.Update
{
    public class UpdateInfoCommand : IRequest<UpdateInfoResponseDto>
    {
        public int HotelId { get; set; }
        public UpdateInfoDto UpdateInfoDto { get; set; }
    }

}
