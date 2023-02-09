using UnityEngine;

namespace CharacterController
{
    public interface IMoveLogic
    {
        void CheckMove();
        void CallMove(Vector2 direction);
        void CallMoveRelease();
    }
}