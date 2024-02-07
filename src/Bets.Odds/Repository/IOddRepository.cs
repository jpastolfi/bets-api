using Bets.Odds.Models;

namespace Bets.Odds.Repository;

public interface IOddRepository
{
    Match Patch(int MatchId, int TeamId, string BetValue);
}