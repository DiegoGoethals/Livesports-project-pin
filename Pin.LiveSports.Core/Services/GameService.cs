using Pin.LiveSports.Core.Entities;
using Pin.LiveSports.Core.Interfaces;
using Pin.LiveSports.Core.Interfaces.Services;

namespace Pin.LiveSports.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IFakeDataBase _fakeDataBase;

        public GameService(IFakeDataBase fakeDataBase)
        {
            _fakeDataBase = fakeDataBase;
        }

        public ICollection<Game> GetAll()
        {
            return _fakeDataBase.GetGames();
        }

        public Game GetById(int id)
        {
            return _fakeDataBase.GetGame(id);
        }

        public void AddEvent(MatchEvent matchEvent)
        {
            _fakeDataBase.AddEvent(matchEvent);
        }
    }
}
