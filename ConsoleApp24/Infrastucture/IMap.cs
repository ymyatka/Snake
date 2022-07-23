using System.Collections.Generic;

namespace ConsoleApp24.Infrastucture
{
    public interface IMap : IDrawble
    {
        int X { get; set; }
        int Y { get; set; }

        int Height { get; set; }
        int Width { get; set; }

        string Name { get; }

        List<IGameObject> Walls { get; }

        bool IsHit(IGameObject item);

        void GenerateFood();

        IPoint Food { get; set; }
    }
}
