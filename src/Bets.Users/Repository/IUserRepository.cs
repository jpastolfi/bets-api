using Bets.Users.DTO;
using Bets.Users.Models;

namespace Bets.Users.Repository;

public interface IUserRepository
{
    User Post(User user);
    User Login(AuthDTORequest login);
}