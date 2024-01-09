using Play_investe.Entity;
using Play_investe.Interface;
using Play_investe.Repository;

namespace Play_investe.Repository
{
    public class EFABoundRepository : EFRepository<Bound>, IBoundRepository
    {
        public EFABoundRepository(ApplicationDbContext context) : base(context)
        {


        }

        public List<Bound> GetFixedBound()
        {
            return _context.Bound.Where(b => b.Type == "Fixed Bound").ToList();
        }

        public List<Bound> GetIndexedBound()
        {
            return _context.Bound.Where(b => b.Type == "Indexed Bound").OrderBy(c => c.LiquidityType).ToList();
        }
 
    }
}