using System;
using UnityEngine;

namespace AsteroidsEcs
{
    [Serializable]
    public struct LightWeaponComponent
    {
        public GameObject bullet;
        [HideInInspector] public bool isAttack;
    }
}
