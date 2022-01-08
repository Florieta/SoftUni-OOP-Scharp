using SnakeGame.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame.Core
{
    public class Engine
    {
        private Direction direction;
        private Dictionary<Direction, Point> pointDirections;
        private Snake snake;
        private double speed;
        public Engine(Snake snake)
        {
            this.snake = snake;
            direction = Direction.Right;
            pointDirections = new Dictionary<Direction, Point>()
            {
                {Direction.Left, new Point(-1, 0) },
                {Direction.Right, new Point(1, 0) },
                {Direction.Up, new Point(0, -1) },
                {Direction.Down, new Point(0, 1) }

            };
            speed = 200;
        }
        public void Run()
        {
            while(true)
            {
                if (Console.KeyAvailable)
                {
                    GetDirection();
                }
                bool tryMove = snake.TryMove(pointDirections[direction]);
                if (!tryMove)
                {
                    Console.WriteLine("Bye Bye");
                    Environment.Exit(0);
                }
                speed -= 0.5;
                Thread.Sleep((int)speed);
            }
        }
       
        private void GetDirection()
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

            if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
        }
    }
}
