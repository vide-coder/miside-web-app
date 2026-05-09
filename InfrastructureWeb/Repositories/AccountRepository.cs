using MiSide.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class AccountRepository
    {
        private static IDictionary<string, Account> _accounts = new Dictionary<string, Account>();

        public void Add(Account account)
        {
            _accounts[account.UserName] = account;
        }

        public Account? GetByUserName(string userName)
        {
            return _accounts.TryGetValue(userName, out Account? account) ? account : null;
        }
    }
}
