using System;
using UnityEngine;

namespace AsteroidsEcs
{
    [Serializable]
    public struct PlayerMovementComponent
    {
        [HideInInspector] public float moveForward;
        [HideInInspector] public float rotation;
        public float rotationStep;
    }
}
