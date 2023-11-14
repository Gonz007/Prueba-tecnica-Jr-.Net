using MediatR;

namespace PruebaCheil.Aplication.Features.Delete
{
    public class DeleteInfoCommandHandler : IRequestHandler<DeleteInfoCommand, DeleteInfoResponseDto>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteInfoCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<DeleteInfoResponseDto> Handle(DeleteInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var hotel = await _dbContext.Hotels.FindAsync(request.HotelId);

                if (hotel == null)
                {
                    return new DeleteInfoResponseDto
                    {
                        Message = $"No se encontró el hotel con el ID {request.HotelId}"
                    };
                }

                _dbContext.Hotels.Remove(hotel);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return new DeleteInfoResponseDto
                {
                    DeletedHotelId = hotel.Id,
                    Message = "Hotel eliminado exitosamente",
                    // Otros campos según tus necesidades
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el hotel: {ex.Message}");
                throw;
            }
        }
    }

}
