using ConsoleApp24.Enum;
using ConsoleApp24.Infrastucture;
using System;
using System.Collections.Generic;

namespace ConsoleApp24.Models
{
    public class MapGenerator
    {
        public IMap Generate(MapType mapType)
        {
            switch (mapType)
            {
                case MapType.Box:
                    return GenerateBox(10, 6, 30, 90);
                case MapType.Road:
                    return new Map(12, 12, 12, 12, "fsa", new List<IGameObject>());
                case MapType.Empty:
                    return new Map(12, 12, 12, 12, "fsa", new List<IGameObject>());
                default:
                    return new Map(12, 12, 12, 12, "fsa", new List<IGameObject>());
            }
        }

        private IMap GenerateBox(int X, int Y, int Height, int Width)
        {
            Line LeftWall = new Line(X, Y, Height, LineType.Vertical, ConsoleColor.Red, '#');
            Line RightWall = new Line(X + Width, Y, Height, LineType.Vertical, ConsoleColor.Red, '#');

            Line UpWall = new Line(X, Y, Width, LineType.Horizontal, ConsoleColor.Red, '#');
            Line DownWall = new Line(X, Y + Height, Width, LineType.Horizontal, ConsoleColor.Red, '#');

            List<IGameObject> walls = new List<IGameObject>() { LeftWall, RightWall, UpWall, DownWall }; 

            return new Map(X, Y, Height, Width, "Box", walls);
        }

    }
}
