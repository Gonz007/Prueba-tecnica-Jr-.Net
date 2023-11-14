using MediatR;

namespace PruebaCheil.Aplication.Features.Delete
{
    public class DeleteInfoCommand : IRequest<DeleteInfoResponseDto>
    {
        public int HotelId { get; set; }
    }
}
