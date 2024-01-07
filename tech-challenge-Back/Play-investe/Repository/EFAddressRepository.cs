using Play_investe.Entity;
using Play_investe.Interface;
using StoreFIAP.Interface;
using StoreFIAP.Repository;

namespace Play_investe.Repository
{
    public class EFAddressRepository : EFRepository<Address>, IAddressRepository
    {
        public EFAddressRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}