using UnityEngine;

namespace CharacterController
{
    public class MoveLogic : IMoveLogic
    {
        public bool IsMoving { get; private set;}
        
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
                IsMoving = false;
            }
            else
            {
                Vector3 force = 
                    //(_moverRB.transform.right * _direction.x + _moverRB.transform.forward * _direction.y)
                    _moverRB.transform.forward 
                    * (_moveData.MoveForce * Time.fixedDeltaTime); 
                _moverRB.AddForce(force);
                RotateTo(_direction.normalized);
                Vector3 velocity = _moverRB.velocity;
                velocity.x = Mathf.Clamp(velocity.x,-_moveData.MaxMoveSpeed,_moveData.MaxMoveSpeed);
                velocity.z = Mathf.Clamp(velocity.z,-_moveData.MaxMoveSpeed,_moveData.MaxMoveSpeed);
                _moverRB.velocity = velocity;
                IsMoving = true;
            }
        }

        private void RotateTo(Vector2 direction)
        {
            
            _moverRB.MoveRotation(Quaternion.LookRotation(new Vector3(direction.x,0,direction.y), Vector3.up));
        }
    }
}