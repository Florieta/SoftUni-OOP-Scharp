
using SnakeGame.Core;
using SnakeGame.GameObjects;
using System;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(100, 20);

            Snake snake = new Snake(wall);

            Engine engine = new Engine(snake);

            engine.Run();
        }
    }
}
