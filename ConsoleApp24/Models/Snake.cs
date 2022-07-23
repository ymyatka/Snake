using ConsoleApp24.Enum;
using ConsoleApp24.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Models
{
    public class Snake:GameObject
    {
        public IPoint _head;
        public IPoint _tail;

        private MoveDirection _direction;

        public Snake(IPoint tail, int length, MoveDirection direction)
        { 
            _tail = tail;
            _direction = direction;

            Init(length);
        }

        private IPoint GetNextHead()
        {
            IPoint nextHead = (IPoint)_head.Clone();
            nextHead.Move(_direction, 1);
            return nextHead;
        }

        private void Init(int lenght)
        {
            points.Add(_tail);

            for (int i = 0; i < lenght; i++)
            {
                IPoint point = (IPoint)points.Last().Clone();
                point.Move(_direction, 1);
                points.Add(point);
            }

            _head = points.Last();
        }

        public void Move()
        {
            DeleteTail();
            AddHead();
            _head.Draw();
        }

        private void AddHead()
        {
            _head = (IPoint)points.Last().Clone();
            _head.Move(_direction, 1);
            points.Add(_head);
        }

        private void DeleteTail()
        {
            points.Remove(_tail);
            _tail.Delete();
            _tail = points[0];
        }

        public void Grow(IPoint food)
        {
            IPoint nextHead = GetNextHead();
            food.Symbol = nextHead.Symbol;
            food.Color = nextHead.Color;
            points.Add(food);
        }

        public void HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (_direction == MoveDirection.Right)
                    {
                        return;
                    }
                    _direction = MoveDirection.Left;
                    break;
                case ConsoleKey.UpArrow:
                    if (_direction == MoveDirection.Down)
                    {
                        return;
                    }
                    _direction = MoveDirection.Up;
                    break;

                case ConsoleKey.RightArrow:
                    if (_direction == MoveDirection.Left)
                    {
                        return;
                    }
                    _direction = MoveDirection.Right;
                    break;

                case ConsoleKey.DownArrow:
                    if (_direction == MoveDirection.Up)
                    {
                        return;
                    }
                    _direction = MoveDirection.Down;
                    break;
            }
        }

        public bool IsHitByItSelf()
        {
            List<IPoint> pointsWithHead = points.Where(p => p.IsHit(_head)).ToList();
            if (pointsWithHead.Count > 1)
            {
                return true;
            }
            return false;
        }

        public bool IsAteFood(IPoint food)
        {
            if (_head.IsHit(food))
            {
                Grow(food);
                return true;
            }
            return false;
        }
    }
}
