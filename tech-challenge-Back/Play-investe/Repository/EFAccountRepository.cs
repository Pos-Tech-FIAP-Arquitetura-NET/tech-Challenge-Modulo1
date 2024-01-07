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

        /// <summary>
        /// Traz o usuario e as informações de conta e investimento
        /// </summary>
        /// <param name="id"></param>        
        /// <returns></returns>
        public Account GetUserFullAccountInformation(int userId)
        {
            var account = _context.Account.FirstOrDefault(acc => acc.IdUser == userId);

            return account;
        }
    }
}
