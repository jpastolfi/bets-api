using TryBets.Odds.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Globalization;

namespace TryBets.Odds.Repository;

public class OddRepository : IOddRepository
{
    protected readonly ITryBetsContext _context;
    public OddRepository(ITryBetsContext context)
    {
        _context = context;
    }

    public Match Patch(int MatchId, int TeamId, string BetValue)
    {
        Match matchToUpdate = _context.Matches.FirstOrDefault(b => b.MatchId == MatchId)!;
        string BetValueConverted = BetValue.Replace(',', '.');
        decimal BetValueDecimal = Decimal.Parse(BetValueConverted, CultureInfo.InvariantCulture);
        if (TeamId != matchToUpdate.MatchTeamAId && TeamId != matchToUpdate.MatchTeamBId) return null!;
        if (matchToUpdate.MatchTeamAId == TeamId) matchToUpdate.MatchTeamAValue += BetValueDecimal; else matchToUpdate.MatchTeamBValue += BetValueDecimal;
        _context.Matches.Update(matchToUpdate);
        _context.SaveChanges();
        return new Match()
        {
            MatchId = matchToUpdate.MatchId,
            MatchDate = matchToUpdate.MatchDate,
            MatchTeamAId = matchToUpdate.MatchTeamAId,
            MatchTeamBId = matchToUpdate.MatchTeamBId,
            MatchTeamAValue = matchToUpdate.MatchTeamAValue,
            MatchTeamBValue = matchToUpdate.MatchTeamBValue,
            MatchFinished = matchToUpdate.MatchFinished,
            MatchWinnerId = matchToUpdate.MatchWinnerId,
            Bets = matchToUpdate.Bets
        };
    }
}