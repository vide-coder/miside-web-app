namespace Application.Interfaces.Services;

public interface IAccountService
{
    void Register(string userName, string firstName, string password);
    string Login(string userName, string password);
}