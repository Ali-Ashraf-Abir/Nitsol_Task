namespace backend.Services;

using System.Text.Json;
using backend.Model;
using backend.Services.Interfaces;

public class UserService : IUserService
{
    private readonly List<User> _users;

    public UserService(IWebHostEnvironment env)
    {
        var path = Path.Combine(env.ContentRootPath, "Users/users.json");
        var json = File.ReadAllText(path);
        _users = JsonSerializer.Deserialize<List<User>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

    }

    public User? ValidateUser(string username, string password)
    {

        return _users.FirstOrDefault(u =>
            u.Username == username &&
            u.Password == password);
    }
}