using MediatR;
namespace PruebaCheil.Aplication.Features.Create
{
    

    public class CreateInfoCommand : IRequest<CreateInfoResponseDto>
    {
        public CreateInfoDto CreateInfoDto { get; set; }
    }

}
