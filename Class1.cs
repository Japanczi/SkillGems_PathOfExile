using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillGems_PathOfExile
{
    public class Gem
    {
        private string name;

        protected string Name { get => name; set => name = value; }
        protected int ReqLevel { get; set; }
        protected Color GemColor { get; set; }
        protected enum Color
        {
            white = 0,
            red = 1,
            green = 2,
            blue = 3
        }

        protected Gem(string name, int level, Color colour)
        {
            if (name == null)
                Name = "Unspecified";
            else
                Name = name;

            if (level <= 0)
                ReqLevel = 1;
            else
                ReqLevel = level;

            if (colour != (Color.white | Color.green | Color.blue | Color.red))
                GemColor = Color.white;
            else
                GemColor = colour;

            GemColor = colour;
        }
            


    }
}
