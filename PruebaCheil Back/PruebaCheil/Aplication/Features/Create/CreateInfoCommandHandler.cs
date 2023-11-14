using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaCheil.Domain.Entities;
using PruebaCheil.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaCheil.Aplication.Features.Create
{
    public class CreateInfoCommandHandler : IRequestHandler<CreateInfoCommand, CreateInfoResponseDto>
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateInfoCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<CreateInfoResponseDto> Handle(CreateInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingHotel = await _dbContext.Hotels.FirstOrDefaultAsync(h => h.Name == request.CreateInfoDto.Name, cancellationToken);
                if (existingHotel != null)
                {
                    return new CreateInfoResponseDto
                    {
                        CreatedHotelId = existingHotel.Id,
                        Message = "El hotel ya existe con el mismo nombre",
                    };
                }

                var newHotel = new Hotel
                {
                    Name = request.CreateInfoDto.Name,
                    Stars = request.CreateInfoDto.Stars,
                };

                _dbContext.Hotels.Add(newHotel);
                await _dbContext.SaveChangesAsync(cancellationToken);

                var createInfoResponseDto = new CreateInfoResponseDto
                {
                    CreatedHotelId = newHotel.Id,
                    Message = "Hotel creado exitosamente",
                };

                return createInfoResponseDto;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error al crear el hotel: {ex.Message}");

                if (ex.InnerException is SqlException sqlException && sqlException.Number == 2627)
                {
                }

                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el hotel: {ex.Message}");
                throw;
            }
        }
    }

}
