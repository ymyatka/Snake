using ConsoleApp24.Infrastucture;
using System;

namespace ConsoleApp24.Models
{
    public class FoodGenerator
    {
        private IMap _map;
        private char _simbol;
        private ConsoleColor _color;
        private Random random = new Random();

        public FoodGenerator(IMap map, char simbol, ConsoleColor color)
        {
            _map = map;
            _simbol = simbol;
            _color = color;
        }

        public Point Generator()
        {
            int X = random.Next(_map.X + 1, _map.Width - 1);
            int Y = random.Next(_map.Y + 1, _map.Height - 1);
            return new Point(X, Y, _simbol, _color);
        }
    }
}
