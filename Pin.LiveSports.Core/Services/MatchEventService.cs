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
    }
}
