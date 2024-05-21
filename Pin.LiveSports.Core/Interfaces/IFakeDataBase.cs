using Pin.LiveSports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.Interfaces
{
    public interface IFakeDataBase
    {
        ICollection<Team> GetTeams();
        ICollection<Game> GetGames();
        void AddGame(Game game);
        void UpdateGame(int id, Game game);
        Game GetGame(int id);
        ICollection<EventType> GetEventTypes();
        void AddEvent(MatchEvent matchEvent);
    }
}
