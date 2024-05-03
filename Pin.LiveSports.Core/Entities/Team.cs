using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.Entities
{
    public class Team
    {
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
