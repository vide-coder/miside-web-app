using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Domain.Entities.Account;

namespace Application.Services
{
    public class AccountService(IAccountRepository accountRepository, IJwtService jwtService) : IAccountService
    {
        public void Register(string userName, string firstName, string password)
        {
            Account account = new Account
            {
                UserName = userName,
                FirstName = firstName,
                Id = Guid.NewGuid(),
            };

            string? passwordHash = new PasswordHasher<Account>().HashPassword(account, password);
            account.PasswordHash = passwordHash;

            accountRepository.Add(account);
        }

        public string Login(string userName, string password)
        {
            Account? account = accountRepository.GetByUserName(userName);
            PasswordVerificationResult result = new PasswordHasher<Account>()
                .VerifyHashedPassword(account, account.PasswordHash, password);

            if (result == PasswordVerificationResult.Success)
            {
                return jwtService.GenerateToken(account);
            }
            else
            {
                throw new Exception("Unauthorized");
            }
        }
    }
}
