namespace Bets.Bets.Services;

public interface IOddService
{
    Task<object> UpdateOdd(int MatchId, int TeamId, decimal BetValue);
}