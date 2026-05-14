using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(Account account);
}