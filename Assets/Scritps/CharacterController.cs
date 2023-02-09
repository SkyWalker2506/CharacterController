using UnityEngine;

namespace CharacterController
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] 
        private CharacterControllerData _characterControllerData;
        private IJumpLogic _jumpLogic;
        private ICollisionDetection _groundDetection;

        private void Awake()
        {
            _groundDetection = new LayerCollisionDetection(_characterControllerData.GroundLayerDetectionData);
            _jumpLogic = new JumpLogic(_characterControllerData.PhysicsData.Rigidbody, _characterControllerData.JumpData, _groundDetection);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _jumpLogic.CallJump();    
            }
            else if(Input.GetKeyUp(KeyCode.Space))
            {
                _jumpLogic.CallJumpRelease();    
            }
            _groundDetection.CheckDetection();
            _jumpLogic.CheckJump();
        }
    }
}

