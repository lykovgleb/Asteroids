using System;
using UnityEngine;

namespace AsteroidsEcs
{
    [Serializable]
    public struct ScreenSizeComponent
    {
        [HideInInspector] public Vector2 lowerLeft;
        [HideInInspector] public Vector2 upperRight;
        public Camera camera;
    }
}
