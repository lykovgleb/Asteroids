using System;
using UnityEngine;

namespace AsteroidsEcs
{
    [Serializable]
    public struct HeavyWeaponAmmoComponent
    {
        public int maxAmmo;
        public float recoveryTime;
        [HideInInspector] public int realAmmo;
        [HideInInspector] public float timer;
    }
}
