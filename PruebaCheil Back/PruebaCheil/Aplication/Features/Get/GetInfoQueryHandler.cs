using MediatR;
using PruebaCheil.Domain.Entities;
using PruebaCheil.Domain.Interfaces;

namespace PruebaCheil.Aplication.Features.Get
{
    public class GetInfoQueryHandler : IRequestHandler<GetInfoQuery, GetInfoResponseDto>
    {
        private readonly IRepository<Hotel> _hotelRepository;
        private readonly ApplicationDbContext _dbContext;

        public GetInfoQueryHandler(
            IRepository<Hotel> hotelRepository,
            ApplicationDbContext dbContext)
        {
            _hotelRepository = hotelRepository;
            _dbContext = dbContext;
        }

        public async Task<GetInfoResponseDto> Handle(GetInfoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var queryHotels = await _hotelRepository.GetAsync();

                if (request.GetInfoDto != null)
                {
                    if (!string.IsNullOrEmpty(request.GetInfoDto.Name))
                    {
                        queryHotels = queryHotels
                            .Where(h => h.Name.Contains(request.GetInfoDto.Name, StringComparison.OrdinalIgnoreCase))
                            .ToList();
                    }

                    if (request.GetInfoDto.Id.HasValue)
                    {
                        queryHotels = queryHotels
                            .Where(h => h.Id == request.GetInfoDto.Id)
                            .ToList();
                    }

                    if (request.GetInfoDto.Stars.HasValue)
                    {
                        queryHotels = queryHotels
                            .Where(h => h.Stars == request.GetInfoDto.Stars)
                            .ToList();
                    }
                }

                GetInfoResponseDto getInfoResponseDto = new GetInfoResponseDto
                {
                    Total = queryHotels.Count(),
                    GetInfoDetail = new List<GetInfoDetail>()
                };

                var hotelsPag = queryHotels
                .OrderBy(h => h.Id)
                .Skip((request.GetInfoDto.PageNumber - 1) * request.GetInfoDto.RowsPerPage)
                .Take(request.GetInfoDto.RowsPerPage)
                .ToList();  


                object dbContextLock = new object();
                Parallel.ForEach(hotelsPag, hotel =>
                {
                    lock (dbContextLock)
                    {
                        var getInfoDetail = new GetInfoDetail
                        {
                            Id = hotel.Id,
                            Name = hotel.Name,
                            Stars = hotel.Stars,
                        };

                        getInfoResponseDto.GetInfoDetail.Add(getInfoDetail);
                    }
                });

                return getInfoResponseDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
