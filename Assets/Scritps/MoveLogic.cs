using UnityEngine;

namespace CharacterController
{
    public class MoveLogic : IMoveLogic
    {
        private Rigidbody _moverRB;
        private MoveData _moveData;
        private Vector2 _direction;

        public MoveLogic(Rigidbody moverRB, MoveData moveData)
        {
            _moverRB = moverRB;
            _moveData = moveData;
        }
        
        public void Update()
        {
            Move();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void Move()
        {
            if (_direction == Vector2.zero)
            {
                Vector3 velocity = _moverRB.velocity;
                velocity.x *=1-_moveData.DragForce * Time.deltaTime;
                velocity.z *=1-_moveData.DragForce * Time.deltaTime;
                _moverRB.velocity = velocity;
            }
            else
            {
                Vector3 force = (Vector3.right * _direction.x + Vector3.forward * _direction.y) * (_moveData.MoveForce * Time.fixedDeltaTime); 
                _moverRB.AddForce(force);
                Vector3 velocity = _moverRB.velocity;
                velocity.x = Mathf.Clamp(velocity.x,-_moveData.MaxMoveSpeed,_moveData.MaxMoveSpeed);
                velocity.z = Mathf.Clamp(velocity.z,-_moveData.MaxMoveSpeed,_moveData.MaxMoveSpeed);
                Debug.Log(velocity);
                _moverRB.velocity = velocity;
            }
        }
    }
}