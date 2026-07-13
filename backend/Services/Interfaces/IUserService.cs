using backend.Model;

namespace backend.Services.Interfaces;

public interface IUserService
{
    User? ValidateUser(string username, string password);
}