using MyBuberDinner.Domain.Entities;

namespace MyBuberDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUser(string email);

    void AddUser(User user);
}