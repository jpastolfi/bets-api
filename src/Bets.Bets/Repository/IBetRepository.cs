using Bets.Bets.DTO;
using Bets.Bets.Models;

namespace Bets.Bets.Repository;

public interface IBetRepository
{
    BetDTOResponse Post(BetDTORequest betRequest, string email);
    BetDTOResponse Get(int BetId, string email);
}