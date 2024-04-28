using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UserService
{
  // users api 
  public static List<User> _users = new List<User>() {
        new User{
            UserId = Guid.Parse("75424b9b-cbd4-49b9-901b-056dd1c6a020"),
            Name = "John Doe",
            Email = "john@example.com",
            Password = "password123",
            Address = "123 Main St",
            IsAdmin = false,
            IsBanned = false,
            CreatedAt = DateTime.Now
        },
        new User{
            UserId = Guid.Parse("24508f7e-94ec-4f0b-b8d6-e8e16a9a3b29"),
            Name = "Alice Smith",
            Email = "alice@example.com",
            Password = "password456",
            Address = "456 Elm St",
            IsAdmin = false,
            IsBanned = false,
            CreatedAt = DateTime.Now
        },
        new User{
            UserId = Guid.Parse("87e5c4f3-d3e5-4e16-88b5-809b2b08b773"),
            Name = "Bob Johnson",
            Email = "bob@example.com",
            Password = "password789",
            Address = "789 Oak St",
            IsAdmin = false,
            IsBanned = false,
            CreatedAt = DateTime.Now
        }
    };

  public async Task<IEnumerable<User>> GetAllUsersService()
  {
    await Task.CompletedTask; // Simulate an asynchronous operation without delay
    return _users.AsEnumerable();
  }

  public Task<User?> GetUserById(Guid userId)
  {
    return Task.FromResult(_users.Find(user => user.UserId == userId));
  }

  public async Task<User> CreateUserService(User newUser)
  {
    await Task.CompletedTask; // Simulate an asynchronous operation without delay
    newUser.UserId = Guid.NewGuid();
    newUser.CreatedAt = DateTime.Now;
    _users.Add(newUser); // store this user in our database
    return newUser;
  }

  public async Task<User?> UpdateUserService(Guid userId, User updateUser)
  {
    await Task.CompletedTask; // Simulate an asynchronous operation without delay
    var existingUser = _users.FirstOrDefault(u => u.UserId == userId);
    if (existingUser != null)
    {
      existingUser.Name = updateUser.Name;
      existingUser.Email = updateUser.Email;
      existingUser.Password = updateUser.Password;
      existingUser.Address = updateUser.Address;
      existingUser.Image = updateUser.Image;
      existingUser.IsAdmin = updateUser.IsAdmin;
      existingUser.IsBanned = updateUser.IsBanned;
    }
    return existingUser;
  }

  public async Task<bool> DeleteUserService(Guid userId)
  {
    await Task.CompletedTask; // Simulate an asynchronous operation without delay
    var userToRemove = _users.FirstOrDefault(u => u.UserId == userId);
    if (userToRemove != null)
    {
      _users.Remove(userToRemove);
      return true;
    }
    return false;
  }
}
