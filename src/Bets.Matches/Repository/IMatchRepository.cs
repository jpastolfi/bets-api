using Bets.Matches.DTO;

namespace Bets.Matches.Repository;

public interface IMatchRepository
{
    IEnumerable<MatchDTOResponse> Get(bool MatchFinished);
}