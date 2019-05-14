using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace game_cell.Models
{
    public class GAME
    {
        public int GAMEId { get; set; }
        public string GAMEName { get; set; }
        public int PlatformsId { get; set; }
        public Platforms Platforms { get; set; }

    }
}
