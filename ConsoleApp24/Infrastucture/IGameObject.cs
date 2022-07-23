using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Infrastucture
{
    public interface IGameObject: IDrawble
    {
        bool IsHit(IPoint point);
        bool IsHit(IGameObject gameObject);
    }
}
