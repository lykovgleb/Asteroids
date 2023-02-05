using System;
using UnityEngine;

namespace AsteroidsEcs
{
    [Serializable]
    public struct MovableComponent
    {
        public Rigidbody2D rigidbody;
        public float speed;
    }
}
