using UnityEngine;

namespace CharacterController
{
    public class JumpLogic : IJumpLogic
    {
        private JumpData _jumpData;
        private Rigidbody _jumperRB;
        private AnimationCurve _jumpAccelerationCurve => _jumpData.JumpAccelerationCurve;
        private float _jumpStep;        
        private float _maxJumpForce=> _jumpData.MaxJumpForce;        
        private float _jumpAccelerationSpeed=> _jumpData.JumpAccelerationSpeed;
        private float _coyoteTime => _jumpData.CoyoteTime;
        private float _jumpBuffer => _jumpData.JumpBuffer;
        private float _jumpBufferReminder;
        private int _jumpLimitBeforeGrounded => _jumpData.JumpLimitBeforeGrounded;
        private int _jumpedBeforeGrounded;
        private float _lastJumpButtonClickedTime;
        private bool _isHighestPointReached;
        private ICollisionDetection _groundDetection;
        private bool _isJumping;
        
        public JumpLogic(Rigidbody jumperRB, JumpData jumpData, ICollisionDetection groundDetection)
        {
            _jumpData = jumpData;
            _jumperRB = jumperRB;
            _groundDetection = groundDetection;
        }

        public void CheckJump()
        {
            if (_groundDetection.IsCollidingStarted)
            {
                _jumpedBeforeGrounded = 0;
            }
            
            
            if ((_jumpedBeforeGrounded == 0 && _jumpBufferReminder > 0 && _coyoteTime > _groundDetection.LastCollidedDifference)
                  ||( _jumpedBeforeGrounded > 0 && _jumpedBeforeGrounded < _jumpLimitBeforeGrounded && _jumpBufferReminder > 0))
            {
                Vector3 velocity = _jumperRB.velocity;
                if (velocity.y < 0)
                {
                    velocity.y = 0;
                    _jumperRB.velocity = velocity;
                }
                _isJumping = true;
                _jumpStep = 0;
                _jumpBufferReminder = 0;
                _jumpedBeforeGrounded++;
            }

            if(_isJumping)
            {
                Jump();
            }
            
            _jumpStep += Time.fixedDeltaTime;
            _jumpBufferReminder -= Time.fixedDeltaTime;

        }

        public void CallJump()
        {
            _jumpBufferReminder = _jumpBuffer;
        }

        public void CallJumpRelease()
        {
            _isJumping = false;
            _jumpBufferReminder = 0;
        }
        
        private void Jump()
        {
            Vector3 force = Vector3.up * (_jumpAccelerationCurve.Evaluate(_jumpStep) * _maxJumpForce * Time.fixedDeltaTime);
            _jumperRB.AddForce(force, ForceMode.VelocityChange);
            _jumpStep = Mathf.Clamp01(_jumpStep + _jumpAccelerationSpeed * Time.deltaTime);
        }

    }
}