using Play_investe.Entity;
using Play_investe.Interface;
using Play_investe.Interface;
using Play_investe.Repository;
using System.Diagnostics.CodeAnalysis;

namespace Play_investe.Repository
{
    [ExcludeFromCodeCoverage]
    public class EFAddressRepository : EFRepository<Address>, IAddressRepository
    {
        public EFAddressRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}