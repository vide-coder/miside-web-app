using Domain.Entities.Account;

namespace Application.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(Account account);
}