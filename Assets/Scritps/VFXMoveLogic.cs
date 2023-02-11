namespace CharacterController
{
    public class VFXMoveLogic : IVFXLogic
    {
        private readonly IMoveLogic _moveLogic;
        private readonly ICollisionDetection _groundDetection;
        private readonly VFXData _vfxData;

        public VFXMoveLogic(IMoveLogic moveLogic, ICollisionDetection groundDetection, VFXData vfxData)
        {
            _moveLogic = moveLogic;
            _groundDetection = groundDetection;
            _vfxData = vfxData;
        }

        public void Update()
        {
            if (_groundDetection.IsColliding && _moveLogic.IsMoving)
            {
               // if (!_vfxData.ParticleSystem.isPlaying)
                //{
                _vfxData.ParticleSystem.Play();
                //}
            }
        }
    }
}