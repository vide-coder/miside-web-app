using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IAccountRepository
{
    void Add(Account account);
    Account? GetByUserName(string userName);
}