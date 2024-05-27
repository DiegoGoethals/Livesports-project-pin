using Pin.LiveSports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.Interfaces.Services
{
    public interface IMatchEventService
    {
        ICollection<EventType> GetEventTypes();
        void HandleEvent(MatchEvent matchEvent);

	}
}
