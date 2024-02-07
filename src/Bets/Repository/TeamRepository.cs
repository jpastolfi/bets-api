using Bets.DTO;

namespace Bets.Repository;

public class TeamRepository : ITeamRepository
{
    protected readonly IBetsContext _context;
    public TeamRepository(IBetsContext context)
    {
        _context = context;
    }

    public IEnumerable<TeamDTOResponse> Get()
    {
        return _context.Teams.Select(t => new TeamDTOResponse
        {
            TeamId = t.TeamId,
            TeamName = t.TeamName
        }).ToList();
    }
}