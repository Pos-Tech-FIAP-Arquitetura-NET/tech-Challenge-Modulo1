using Play_investe.Entity;
using Play_investe.Interface;
using Play_investe.Repository;
using System.Diagnostics.CodeAnalysis;

namespace Play_investe.Repository
{
    [ExcludeFromCodeCoverage]
    public class EFAInvestimentRepository : EFRepository<Investment>, IInvestimentRepository
    {
        public EFAInvestimentRepository(ApplicationDbContext context) : base(context)
        {

        }

        public List<Investment> GetInvestment(int Id)
        {
            var investment = _context.Investment.Where(x => x.IdAccount == Id).ToList();

            return investment;
        }
    }
}