using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.Entities
{
    public class Player
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int Points { get; set; }
        public int Assists { get; set; }
        public int Rebounds { get; set; }
        public int Steals { get; set; }
        public int Blocks { get; set; }
        public int FieldGoalsAttempted { get; set; }
        public int FieldGoalsMade { get; set; }
        public int ThreePointFieldGoalsAttempted { get; set; }
        public int ThreePointFieldGoalsMade { get; set; }
        public int FreeThrowsAttempted { get; set; }
        public int FreeThrowsMade { get; set; }
        public int Turnovers { get; set; }
        public int PersonalFouls { get; set; }
        public bool IsBenched { get; set; }
        public bool IsFouledOut { get; set; }
    }
}
