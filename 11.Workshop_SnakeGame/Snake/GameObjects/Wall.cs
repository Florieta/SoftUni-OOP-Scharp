using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';
        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            this.InitializeWall();
        }

        private void InitializeWall()
        {
            InitializeHorizontal(0);
            InitializeHorizontal(TopY);
            InitializeVertical(0);
            InitializeVertical(LeftX);
            //Console.WriteLine();
            
        }

        private void InitializeVertical(int leftX)
        {
            
            for (int topY = 0; topY < TopY; topY++)
            {
                Draw(leftX, topY, wallSymbol);

            }
        }

        private void InitializeHorizontal(int topY)
        {
            for (int leftX = 0; leftX < LeftX; leftX++)
            {
                Draw(leftX, topY, wallSymbol);
            }

        }
    }
}
