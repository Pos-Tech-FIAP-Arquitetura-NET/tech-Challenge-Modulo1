using Play_investe.Entity;
using Play_investe.Interface;

namespace Play_investe.Interface
{
    public interface IBoundRepository : IRepository<Bound>
    {

        List<Bound> GetFixedBound();
        List<Bound> GetIndexedBound();
    }
}
