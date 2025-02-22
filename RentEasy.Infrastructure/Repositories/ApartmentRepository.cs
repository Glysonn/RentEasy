using RentEasy.Domain.Apartments;

namespace RentEasy.Infrastructure.Repositories;

internal sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(ApplicationDbContext context) 
        : base(context)
    {
    }
}
