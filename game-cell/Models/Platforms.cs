using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace game_cell.Models
{
    public class Platforms
    {
        public int PlatformsId { get;set; }
        public string Name { get; set; }
        public List<GAME> GAMEs { get; set; }
        //public string PictureUrl { get; set; }
    }
}
