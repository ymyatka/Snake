using ConsoleApp24.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
