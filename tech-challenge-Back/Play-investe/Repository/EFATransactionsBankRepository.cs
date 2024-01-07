using Play_investe.Entity;
using Play_investe.Interface;
using StoreFIAP.Repository;

namespace Play_investe.Repository
{
    public class EFATransactionsBankRepository : EFRepository<TransactionsBank>, ITransactionsBankRepository
    {
        public EFATransactionsBankRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}