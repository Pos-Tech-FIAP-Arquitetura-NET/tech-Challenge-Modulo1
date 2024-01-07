using Play_investe.Entity;
using Play_investe.Interface;
using Play_investe.Entity;
using Play_investe.Interface;
using Play_investe.Repository;
using UserTemplate.Services;

namespace Play_investe.Repository
{
    public class EFAccountRepository : EFRepository<Account>, IAccountRepository
    {
        public EFAccountRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
