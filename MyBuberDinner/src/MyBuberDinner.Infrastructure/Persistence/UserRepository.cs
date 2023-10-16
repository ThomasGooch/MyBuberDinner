using MyBuberDinner.Application.Common.Interfaces.Persistence;
using MyBuberDinner.Domain.Entities;

namespace MyBuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = [];
    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public User? GetUser(string email)
    {
       return _users.SingleOrDefault(user => user.Email == email);
    }
}
