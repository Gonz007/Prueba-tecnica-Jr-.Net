using MediatR;

namespace PruebaCheil.Aplication.Features.Update
{
    public class UpdateInfoCommandHandler : IRequestHandler<UpdateInfoCommand, UpdateInfoResponseDto>
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateInfoCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<UpdateInfoResponseDto> Handle(UpdateInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var hotel = await _dbContext.Hotels.FindAsync(request.HotelId);

                if (hotel == null)
                {
                    return new UpdateInfoResponseDto
                    {
                        Message = $"No se encontró el hotel con el ID {request.HotelId}"
                    };
                }

                // Actualizar propiedades según UpdateInfoDto
                hotel.Name = request.UpdateInfoDto.Name;
                hotel.Stars = request.UpdateInfoDto.Stars;

                // Guardar los cambios en la base de datos
                await _dbContext.SaveChangesAsync(cancellationToken);

                return new UpdateInfoResponseDto
                {
                    UpdatedHotelId = hotel.Id,
                    Message = "Hotel actualizado exitosamente",
                    // Otros campos según tus necesidades
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el hotel: {ex.Message}");
                throw;
            }
        }
    }

}
