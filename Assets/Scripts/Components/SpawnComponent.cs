using System;
using UnityEngine;

namespace AsteroidsEcs
{
    [Serializable]
    public struct SpawnComponent
    {
        public GameObject prefab;
        public float spawnTime;
        [HideInInspector] public float timer;
    }
}
