using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameObjects
{
    public class FoodAsterisk : Food
    {
        public FoodAsterisk(Wall wall) 
            : base(wall, '*', 1)
        {
        }
    }
}
