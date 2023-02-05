using System;
using UnityEngine;

namespace AsteroidsEcs
{
    [Serializable]
    public struct HeavyWeaponComponent
    {
        public GameObject prefab;
        [HideInInspector] public bool isAttack;
    }
}
