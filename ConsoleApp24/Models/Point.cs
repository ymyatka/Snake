using ConsoleApp24.Enum;
using ConsoleApp24.Infrastucture;
using System;

namespace ConsoleApp24.Models
{
    public class Point : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public char Symbol { get; set; }

        public ConsoleColor Color { get; set; }

        public Point(int x, int y, char symbol, ConsoleColor color)
        {
            X = x;
            Y = y;
            Symbol = symbol;
            Color = color;
        }

        public void Draw()
        {

            Console.ForegroundColor = Color;
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);

            Console.ResetColor();
        }

        public void Delete()
        {
            Symbol = ' ';
            Draw();
        }

        /// <summary>
        /// Двигает точку
        /// </summary>
        /// <param name="direction">направление движения</param>
        /// <param name="count">Количество пикселей</param>
        public void Move(MoveDirection direction, int count)
        {
            switch (direction)
            {
                case MoveDirection.Left:
                    X -= count;
                    break;
                case MoveDirection.Right:
                    X += count;
                    break;
                case MoveDirection.Up:
                    Y -= count;
                    break;
                case MoveDirection.Down:
                    Y += count;
                    break;
            }
        }

        public object Clone()
        {
            return new Point(X, Y, Symbol, Color);
        }

        public bool IsHit(IPoint point)
        {
            return point.X == X && point.Y == Y;
        }
    }
}
