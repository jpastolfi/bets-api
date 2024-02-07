using Bets.DTO;
using Bets.Models;

namespace Bets.Repository;

public interface IUserRepository
{
    User Post(User user);
    User Login(AuthDTORequest login);
}