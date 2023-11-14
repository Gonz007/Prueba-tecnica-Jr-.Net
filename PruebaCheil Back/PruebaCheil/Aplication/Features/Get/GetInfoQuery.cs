using MediatR;

namespace PruebaCheil.Aplication.Features.Get
{
    public class GetInfoQuery : IRequest<GetInfoResponseDto>
    {
        public GetInfoDto GetInfoDto { get; set; }

        public GetInfoQuery(GetInfoDto getInfoDto)
        {
            GetInfoDto = getInfoDto;
        }
    }
}
