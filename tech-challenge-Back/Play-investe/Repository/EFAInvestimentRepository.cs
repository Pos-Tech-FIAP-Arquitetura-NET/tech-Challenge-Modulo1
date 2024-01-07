using Play_investe.Entity;
using Play_investe.Interface;
using Play_investe.Repository;

namespace Play_investe.Repository
{
    public class EFAInvestimentRepository : EFRepository<Investment>, IInvestimentRepository
    {
        public EFAInvestimentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}