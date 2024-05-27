using Pin.LiveSports.Core.Entities;
using Pin.LiveSports.Core.Interfaces;
using static System.Formats.Asn1.AsnWriter;
using System.IO;

namespace Pin.LiveSports.Infrastructure.Data
{
    // Fake database to store data, I will store 4 teams of 10 players each here for testing purposes
    public class FakeDatabase : IFakeDataBase
    {
        private ICollection<Team> Teams;
        private ICollection<Game> Games;
        private ICollection<EventType> EventTypes;

        public FakeDatabase()
        {
            Teams = new List<Team>();
            Games = new List<Game>();
            EventTypes = new List<EventType>();
            PopulateTeams();
            GenerateGames();
            PopulateEventTypes();
        }

        public ICollection<Team> GetTeams()
        {
            return Teams;
        }

        public ICollection<Game> GetGames()
        {
            return Games;
        }

        public void AddGame(Game game)
        {
            Games.Add(game);
        }

        public void UpdateGame(int id, Game game)
        {
            var gameToUpdate = Games.FirstOrDefault(g => g.Id == id);
            gameToUpdate = game;
        }

        public Game GetGame(int id)
        {
               return Games.FirstOrDefault(g => g.Id == id);
        }

        public ICollection<EventType> GetEventTypes()
        {
            return EventTypes;
        }

        // This method populates the teams with players
        private void PopulateTeams()
        {
            var Team1 = new Team
            {
                Name = "Philadelphia 76ers",
                Players = new List<Player>
                {
                    new Player { Name = "Ben Simmons", Number = 25 },
                    new Player { Name = "Joel Embiid", Number = 21 },
                    new Player { Name = "Tobias Harris", Number = 12 },
                    new Player { Name = "Seth Curry", Number = 31 },
                    new Player { Name = "Danny Green", Number = 14 },
                    new Player { Name = "Matisse Thybulle", Number = 22 },
                    new Player { Name = "Dwight Howard", Number = 39 },
                    new Player { Name = "Furkan Korkmaz", Number = 30 },
                    new Player { Name = "Tyrese Maxey", Number = 0 },
                    new Player { Name = "Shake Milton", Number = 18 }
                }
            };

            var Team2 = new Team
            {
                Name = "Brooklyn Nets",
                Players = new List<Player>
                {
                    new Player { Name = "Kevin Durant", Number = 7 },
                    new Player { Name = "Kyrie Irving", Number = 11 },
                    new Player { Name = "James Harden", Number = 13 },
                    new Player { Name = "Joe Harris", Number = 12 },
                    new Player { Name = "DeAndre Jordan", Number = 6 },
                    new Player { Name = "Jeff Green", Number = 8 },
                    new Player { Name = "Bruce Brown", Number = 1 },
                    new Player { Name = "Landry Shamet", Number = 20 },
                    new Player { Name = "Tyler Johnson", Number = 10 },
                    new Player { Name = "Timothé Luwawu-Cabarrot", Number = 9 }
                }
            };

            var Team3 = new Team
            {
                Name = "Los Angeles Lakers",
                Players = new List<Player>
                {
                    new Player { Name = "LeBron James", Number = 23 },
                    new Player { Name = "Anthony Davis", Number = 3 },
                    new Player { Name = "Dennis Schröder", Number = 17 },
                    new Player { Name = "Kentavious Caldwell-Pope", Number = 1 },
                    new Player { Name = "Marc Gasol", Number = 14 },
                    new Player { Name = "Kyle Kuzma", Number = 0 },
                    new Player { Name = "Montrezl Harrell", Number = 15 },
                    new Player { Name = "Alex Caruso", Number = 4 },
                    new Player { Name = "Wesley Matthews", Number = 9 },
                    new Player { Name = "Markieff Morris", Number = 88 }
                }
            };

            var Team4 = new Team
            {
                Name = "Los Angeles Clippers",
                Players = new List<Player>
                {
                    new Player { Name = "Kawhi Leonard", Number = 2 },
                    new Player { Name = "Paul George", Number = 13 },
                    new Player { Name = "Ivica Zubac", Number = 40 },
                    new Player { Name = "Patrick Beverley", Number = 21 },
                    new Player { Name = "Nicolas Batum", Number = 33 },
                    new Player { Name = "Serge Ibaka", Number = 9 },
                    new Player { Name = "Lou Williams", Number = 23 },
                    new Player { Name = "Luke Kennard", Number = 5 },
                    new Player { Name = "Reggie Jackson", Number = 1 },
                    new Player { Name = "Marcus Morris", Number = 31 }
                }
            };

            Teams.Add(Team1);
            Teams.Add(Team2);
            Teams.Add(Team3);
            Teams.Add(Team4);
        }

        // This generates 2 games for the start of the application
        private void GenerateGames()
        {
            var game1 = new Game
            {
                Id = 1,
                HomeTeam = Teams.ElementAt(0),
                AwayTeam = Teams.ElementAt(1),
                HomeTeamScore = 0,
                AwayTeamScore = 0,
                Events = new List<MatchEvent>(),
                StartTime = DateTime.Now.AddHours(1)
            };

            var game2 = new Game
            {
                Id = 2,
                HomeTeam = Teams.ElementAt(2),
                AwayTeam = Teams.ElementAt(3),
                HomeTeamScore = 0,
                AwayTeamScore = 0,
                Events = new List<MatchEvent>(),
                StartTime = DateTime.Now.AddHours(2)
            };

            Games.Add(game1);
            Games.Add(game2);
        }

        // Add all the event types
        private void PopulateEventTypes()
        {
            var types = new List<string>
            {
                "Field Goal Attempt",
                "Field Goal Made",
                "Three Point Attempt",
                "Three Point Made",
                "Free Throw Attempt",
                "Free Throw Made",
                "Foul",
                "Substitution",
                "Timeout",
                "Rebound",
                "Steal",
                "Block",
                "Turnover",
                "Start",
                "End"
            };

            foreach (var eventType in types)
            {
                EventTypes.Add(new EventType { Name = eventType });
            }
        }

        public void AddEvent(MatchEvent matchEvent)
        {
            var game = Games.FirstOrDefault(g => g.Id == matchEvent.GameId);
            game.Events.Add(matchEvent);
        }
    }
}
