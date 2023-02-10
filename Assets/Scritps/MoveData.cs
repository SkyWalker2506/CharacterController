using System;
using UnityEngine;

namespace CharacterController
{
    [Serializable]
    public class MoveData
    {
        public float MoveForce;        
        public float MaxMoveSpeed;        
        [Range(0,50)]
        public float DragForce;        
    }
}