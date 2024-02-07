using Bets.DTO;
using Bets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bets.Repository;

public class BetRepository : IBetRepository
{
    protected readonly IBetsContext _context;
    public BetRepository(IBetsContext context)
    {
        _context = context;
    }

    public BetDTOResponse Post(BetDTORequest betRequest, string email)
    {
        User foundUser = _context.Users.FirstOrDefault(x => x.Email == email)!;
        if (foundUser == null) throw new Exception("User not found");

        Match foundMatch = _context.Matches.FirstOrDefault(m => m.MatchId == betRequest.MatchId)!;
        if (foundMatch == null) throw new Exception("Match not found");

        Team foundTeam = _context.Teams.FirstOrDefault(t => t.TeamId == betRequest.TeamId)!;
        if (foundTeam == null) throw new Exception("Team not found");

        if (foundMatch.MatchFinished) throw new Exception("Match finished");

        if (foundMatch.MatchTeamAId != betRequest.TeamId && foundMatch.MatchTeamBId != betRequest.TeamId) throw new Exception("Team is not in this match");

        Bet newBet = new Bet
        {
            UserId = foundUser.UserId,
            MatchId = betRequest.MatchId,
            TeamId = betRequest.TeamId,
            BetValue = betRequest.BetValue
        };
        _context.Bets.Add(newBet);
        _context.SaveChanges();

        Bet createdBet = _context.Bets.Include(b => b.Team).Include(b => b.Match).Where(b => b.BetId == newBet.BetId).FirstOrDefault()!;

        if (foundMatch.MatchTeamAId == betRequest.TeamId) foundMatch.MatchTeamAValue += betRequest.BetValue;
        else foundMatch.MatchTeamBValue += betRequest.BetValue;
        _context.Matches.Update(foundMatch);
        _context.SaveChanges();

        return new BetDTOResponse
        {
            BetId = createdBet.BetId,
            MatchId = createdBet.MatchId,
            TeamId = createdBet.TeamId,
            BetValue = createdBet.BetValue,
            MatchDate = createdBet.Match!.MatchDate,
            TeamName = createdBet.Team!.TeamName,
            Email = createdBet.User!.Email
        };
    }
    public BetDTOResponse Get(int BetId, string email)
    {
        User foundUser = _context.Users.FirstOrDefault(x => x.Email == email)!;
        if (foundUser == null) throw new Exception("User not found");

        Bet foundBet = _context.Bets.Include(b => b.Team).Include(b => b.Match).Where(b => b.BetId == BetId).FirstOrDefault()!;
        if (foundBet == null) throw new Exception("Bet not found");

        if (foundBet.User!.Email != email) throw new Exception("Bet view not allowed");

        return new BetDTOResponse
        {
            BetId = foundBet.BetId,
            MatchId = foundBet.MatchId,
            TeamId = foundBet.TeamId,
            BetValue = foundBet.BetValue,
            MatchDate = foundBet.Match!.MatchDate,
            TeamName = foundBet.Team!.TeamName,
            Email = foundBet.User!.Email
        };
    }
}