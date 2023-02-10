using UnityEngine;

namespace CharacterController
{
    public interface IMoveLogic
    {
        void Update();
        void SetDirection(Vector2 direction);
    }
}