using Pin.LiveSports.Core.Entities;
using Pin.LiveSports.Core.Interfaces;
using Pin.LiveSports.Core.Interfaces.Services;

namespace Pin.LiveSports.Core.Services
{
    public class MatchEventService : IMatchEventService
    {
        private readonly IFakeDataBase _fakeDataBase;

        public MatchEventService(IFakeDataBase fakeDataBase)
        {
            _fakeDataBase = fakeDataBase;
        }

        public ICollection<EventType> GetEventTypes()
        {
            return _fakeDataBase.GetEventTypes();
        }

        public void HandleEvent(MatchEvent matchEvent)
		{
			Player player;
			Player player2;
			Game game = _fakeDataBase.GetGame(matchEvent.GameId);
			switch (matchEvent.EventType.Name)
			{
				case "Field Goal Attempt":
					player = matchEvent.Players.FirstOrDefault();
					player.FieldGoalsAttempted++;
					break;
				case "Field Goal Made":
					player = matchEvent.Players.FirstOrDefault();
					if (matchEvent.Players.Count == 2)
                    {
                        player2 = matchEvent.Players.LastOrDefault();
                        player.FieldGoalsAttempted++;
                        player.FieldGoalsMade++;
                        player.Points += 2;
                        player2.Assists++;
                    }
                    else
                    {
                        player.FieldGoalsAttempted++;
                        player.FieldGoalsMade++;
                        player.Points += 2;
                    }
					if (game.HomeTeam.Players.Contains(player))
					{
						game.HomeTeamScore += 2;
					}
					else
					{
						game.AwayTeamScore += 2;
					}
					break;
				case "Three Point Attempt":
					player = matchEvent.Players.FirstOrDefault();
					player.ThreePointFieldGoalsAttempted++;
					player.FieldGoalsAttempted++;
					break;
				case "Three Point Made":
					player = matchEvent.Players.FirstOrDefault();
					if (matchEvent.Players.Count == 2)
                    {
                        player2 = matchEvent.Players.LastOrDefault();
                        player.ThreePointFieldGoalsAttempted++;
                        player.ThreePointFieldGoalsMade++;
                        player.FieldGoalsAttempted++;
                        player.FieldGoalsMade++;
                        player.Points += 3;
                        player2.Assists++;
                    }
                    else
                    {
                        player.ThreePointFieldGoalsAttempted++;
                        player.ThreePointFieldGoalsMade++;
                        player.FieldGoalsAttempted++;
                        player.FieldGoalsMade++;
                        player.Points += 3;
                    }
					if (game.HomeTeam.Players.Contains(player))
					{
						game.HomeTeamScore += 3;
					}
					else
					{
						game.AwayTeamScore += 3;
					}
					break;
				case "Free Throw Attempt":
					player = matchEvent.Players.FirstOrDefault();
					player.FreeThrowsAttempted++;
					break;
				case "Free Throw Made":
					player = matchEvent.Players.FirstOrDefault();
					player.FreeThrowsAttempted++;
					player.FreeThrowsMade++;
					player.Points += 1;
					if (game.HomeTeam.Players.Contains(player))
					{
						game.HomeTeamScore += 1;
					}
					else
					{
						game.AwayTeamScore += 1;
					}
					break;
				case "Foul":
					player = matchEvent.Players.FirstOrDefault();
					player.PersonalFouls++;
					if (player.PersonalFouls == 6)
					{
						player.IsFouledOut = true;
					}
					break;
				case "Rebound":
					player = matchEvent.Players.FirstOrDefault();
					player.Rebounds++;
                    break;
				case "Steal":
					player = matchEvent.Players.FirstOrDefault();
					player.Steals++;
                    break;
				case "Turnover":
					player = matchEvent.Players.FirstOrDefault();
					player.Turnovers++;
					break;
				case "Block":
					player = matchEvent.Players.FirstOrDefault();
					player.Blocks++;
					break;
			}
		}
    }
}
