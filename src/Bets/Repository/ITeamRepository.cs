using Bets.DTO;

namespace Bets.Repository;

public interface ITeamRepository
{
    IEnumerable<TeamDTOResponse> Get();
}