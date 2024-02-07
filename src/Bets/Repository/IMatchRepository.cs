using Bets.DTO;

namespace Bets.Repository;

public interface IMatchRepository
{
    IEnumerable<MatchDTOResponse> Get(bool MatchFinished);
}