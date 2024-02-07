using Bets.Matches.DTO;

namespace Bets.Matches.Repository;

public interface ITeamRepository
{
    IEnumerable<TeamDTOResponse> Get();
}