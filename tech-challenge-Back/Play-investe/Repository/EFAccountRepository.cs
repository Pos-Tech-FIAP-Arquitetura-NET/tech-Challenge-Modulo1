using Play_investe.Entity;
using Play_investe.Interface;
using StoreFIAP.Entity;
using StoreFIAP.Interface;
using StoreFIAP.Repository;
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
