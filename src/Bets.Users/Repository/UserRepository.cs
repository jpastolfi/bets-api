using Bets.Users.Models;
using Bets.Users.DTO;

namespace Bets.Users.Repository;

public class UserRepository : IUserRepository
{
    protected readonly IBetsContext _context;
    public UserRepository(IBetsContext context)
    {
        _context = context;
    }

    public User Post(User user)
    {
        var userFound = _context.Users.Where(u => u.Email == user.Email);
        if (userFound.Count() > 0) throw new Exception("E-mail already used");
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }
    public User Login(AuthDTORequest login)
    {
        var userFound = _context.Users.Where(user => user.Email == login.Email);
        if (userFound.Count() == 0) throw new Exception("Authentication failed");
        if (userFound.First().Password != login.Password) throw new Exception("Authentication failed");
        return userFound.FirstOrDefault()!;
    }
}