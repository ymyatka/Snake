using ConsoleApp24.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp24.Models
{
    public abstract class GameObject : IGameObject
    {
        public List<IPoint> points = new List<IPoint>();

        public void Draw()
        {
            foreach (var point in points)
            {
                Console.ForegroundColor = point.Color;
                point.Draw();
                Console.ResetColor();
            }
        }

        public bool IsHit(IPoint point)
        {
            /*
            foreach (var objectItem in points)
            {
                if (point.IsHit(objectItem))
                {
                    return true;
                }
            }
            return false;
            */

            return points.Any(p => p.IsHit(point));
        }

        public bool IsHit(IGameObject gameObject)
        {
            /*
            foreach (var objectItem in points)
            {
                if (gameObject.IsHit(objectItem))
                {
                    return true;
                }
            }
            return false;
            */

            return points.Any(p => gameObject.IsHit(p));
        }
    }
}
