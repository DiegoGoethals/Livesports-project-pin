using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.Entities
{
    public class MatchEvent
    {
        public string Description { get; set; }
        public int Time { get; set; }
        public Team Team { get; set; }
        public Player Player { get; set; }
    }
}
