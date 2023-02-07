namespace CharacterController
{
    public interface ICollisionDetection
    {
        public bool IsColliding { get; }
        public float LastCollided { get; }
        public void CheckDetection();

    }
}