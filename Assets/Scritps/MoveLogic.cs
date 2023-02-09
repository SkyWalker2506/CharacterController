using UnityEngine;

namespace CharacterController
{
    public class MoveLogic : IMoveLogic
    {
        private Rigidbody _moverRB;
        private MoveData _moveData;
        private Vector2 _moveVector;

        public MoveLogic(Rigidbody moverRB, MoveData moveData)
        {
            _moverRB = moverRB;
            _moveData = moveData;
        }
        
        public void CheckMove()
        {
            Move();
        }

        public void CallMove(Vector2 direction)
        {
            _moveVector = direction;
        }

        public void CallMoveRelease()
        {
            _moveVector = Vector2.zero;
        }

        private void Move()
        {
            Vector3 force = _moveData.MoveForce*(Vector3.right * _moveVector.x + Vector3.forward * _moveVector.y)*Time.fixedDeltaTime; 
            _moverRB.AddForce(force);
        }
    }
}