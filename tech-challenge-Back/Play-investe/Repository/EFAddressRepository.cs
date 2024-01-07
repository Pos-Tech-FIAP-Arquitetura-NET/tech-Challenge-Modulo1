using Play_investe.Entity;
using Play_investe.Interface;
using Play_investe.Interface;
using Play_investe.Repository;

namespace Play_investe.Repository
{
    public class EFAddressRepository : EFRepository<Address>, IAddressRepository
    {
        public EFAddressRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}