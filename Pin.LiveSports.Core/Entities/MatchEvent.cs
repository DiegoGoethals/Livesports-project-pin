using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.Entities
{
    public enum EventType
    {
        Score,
        ShotAttempt,
        TypeOfShot,
        MissedShot,
        MadeShot,
        Foul,
        Substitution,
        Timeout,
        Assist,
        Rebound,
        Steal,
        Block,
        Turnover,
        Start,
        End
    }
    public class MatchEvent
    {
        public string Description { get; set; }
        public int Time { get; set; }
        public Team Team { get; set; }
        public ICollection<Player> Players { get; set; }
        public EventType EventType { get; set; }
    }
}
