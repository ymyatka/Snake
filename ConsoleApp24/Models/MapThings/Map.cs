using ConsoleApp24.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp24.Models
{
    public class Map : IMap
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public string Name { get; set; }

        public List<IGameObject> Walls { get; set; }

        public IPoint Food { get; set; }

        public FoodGenerator foodGenerator;

        public Random random = new Random();

        public Map(int x, int y, int height, int width, string name, List<IGameObject> walls)
        {
            Name = name;
            Y = y;
            X = x;
            Width = width;
            Height = height;
            Walls = walls;
            foodGenerator = new FoodGenerator(this, 'O', ConsoleColor.Green);
        }

        public void Draw()
        {
            foreach (var wall in Walls)
            {
                wall.Draw();
            }
        }

        public bool IsHit(IGameObject item)
        {
            return Walls.Any(w => w.IsHit(item));
        }

        public void GenerateFood()
        {
            Food = foodGenerator.Generator();
            Food.Draw();
        }
    }
}