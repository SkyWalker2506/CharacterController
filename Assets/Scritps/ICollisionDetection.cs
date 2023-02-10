namespace CharacterController
{
    public interface ICollisionDetection
    {
        bool IsCollidingStarted { get; }
        bool IsColliding { get; }
        bool IsCollidingEnded { get; }
        float LastCollided { get; }
        float LastCollidedDifference { get; }
        void Update();
    }
}