using ConsoleApp24.Enum;
using System;

namespace ConsoleApp24.Infrastucture
{
    public interface IPoint: IDrawble, ICloneable
    {
        int X { get; set; }
        int Y { get; set; }

        ConsoleColor Color { get; set; }

        char Symbol { get; set; }
        
        void Move(MoveDirection direction, int count);

        void Delete();

        bool IsHit(IPoint point);      
    }
}
