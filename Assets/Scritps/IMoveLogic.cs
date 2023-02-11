using UnityEngine;

namespace CharacterController
{
    public interface IMoveLogic
    {
        bool IsMoving { get; }
        void Update();
        void SetDirection(Vector2 direction);
    }
}