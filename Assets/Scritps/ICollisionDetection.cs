namespace CharacterController
{
    public interface ICollisionDetection
    {
        bool IsColliding { get; }
        float LastCollided { get; }
        float LastCollidedDifference { get; }
        bool ShowDebug{ get; }
        void CheckDetection();
    }
}