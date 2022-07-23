using ConsoleApp24.Enum;
using System;

namespace ConsoleApp24.Models
{
    public class Line : GameObject
    {
        public Line(int x, int y, int length, LineType type, ConsoleColor color, char symbol)
        {
            InitPoints(x, y, length, type, color, symbol);
        }

        private void InitPoints(int x, int y, int length, LineType type, ConsoleColor color, char symbol)
        {
            switch (type)
            {
                case LineType.Vertical:
                    for (int i = 0; i < length; i++)
                    {
                        points.Add(new Point(x, y++, symbol, color));
                    }
                    break;
                case LineType.Horizontal:
                    for (int i = 0; i < length; i++)
                    {
                        points.Add(new Point(x++, y, symbol, color));
                    }
                    break;

            }
        }
    }
}
