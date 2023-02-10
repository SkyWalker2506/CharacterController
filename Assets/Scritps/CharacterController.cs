using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CharacterController
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] 
        private CharacterControllerData _characterControllerData;
        private IMoveLogic _moveLogic;
        private IJumpLogic _jumpLogic;
        private ICollisionDetection _groundDetection;
        private PlayerInputActions _playerInputActions;
        
        private void Awake()
        {
            _groundDetection = new LayerCollisionDetection(_characterControllerData.GroundLayerDetectionData);
            _moveLogic = new MoveLogic(_characterControllerData.PhysicsData.Rigidbody, _characterControllerData.MoveData);
            _jumpLogic = new JumpLogic(_characterControllerData.PhysicsData.Rigidbody, _characterControllerData.JumpData, _groundDetection);
            _playerInputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _playerInputActions.Enable();
        }

        private void OnDisable()
        {
            _playerInputActions.Disable();
        }
        
        private void Update()
        {
            if(_playerInputActions.Player.Jump.WasPressedThisFrame())
            {
                _jumpLogic.CallJump();    
            }
            else if(_playerInputActions.Player.Jump.WasReleasedThisFrame())
            {
                _jumpLogic.CallJumpRelease();    
            }
            _moveLogic.SetDirection(_playerInputActions.Player.Move.ReadValue<Vector2>());
            _groundDetection.Update();
            _jumpLogic.Update();
            _moveLogic.Update();
        }
    }
}

