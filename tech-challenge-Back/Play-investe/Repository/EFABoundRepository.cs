using Play_investe.Entity;
using Play_investe.Interface;
using StoreFIAP.Repository;

namespace Play_investe.Repository
{
    public class EFABoundRepository : EFRepository<Bound>, IBoundRepository
    {
        public EFABoundRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}