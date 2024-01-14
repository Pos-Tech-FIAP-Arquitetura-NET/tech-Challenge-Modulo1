using Play_investe.Entity;
using Play_investe.Interface;
using Play_investe
    .Repository;
using System.Diagnostics.CodeAnalysis;

namespace Play_investe.Repository
{
    [ExcludeFromCodeCoverage]
    public class EFATransactionsBankRepository : EFRepository<TransactionsBank>, ITransactionsBankRepository
    {
        public EFATransactionsBankRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}