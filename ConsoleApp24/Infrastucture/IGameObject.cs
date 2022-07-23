namespace ConsoleApp24.Infrastucture
{
    public interface IGameObject : IDrawble
    {
        bool IsHit(IPoint point);
        bool IsHit(IGameObject gameObject);
    }
}
