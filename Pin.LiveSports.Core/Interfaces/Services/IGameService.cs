using Pin.LiveSports.Core.Entities;

namespace Pin.LiveSports.Core.Interfaces.Services
{
    public interface IGameService
    {
        ICollection<Game> GetAll();
        Game GetById(int id);
        void AddEvent(MatchEvent matchEvent);
    }
}
