using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class HeavyWeaponAmmoSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<HeavyWeaponAmmoComponent> heavyWeaponAmmoFilter = null;

        public void Init()
        {
            foreach (var i in heavyWeaponAmmoFilter)
            {
                ref var heavyWeaponAmmoComponent = ref heavyWeaponAmmoFilter.Get1(i);

                heavyWeaponAmmoComponent.realAmmo = heavyWeaponAmmoComponent.maxAmmo;
                heavyWeaponAmmoComponent.timer = heavyWeaponAmmoComponent.recoveryTime;

            }
        }

        public void Run()
        {
            foreach (var i in heavyWeaponAmmoFilter)
            {
                ref var entity = ref heavyWeaponAmmoFilter.GetEntity(i);
                ref var heavyWeaponAmmoComponent = ref heavyWeaponAmmoFilter.Get1(i);

                ref var realAmmo = ref heavyWeaponAmmoComponent.realAmmo;
                ref var maxAmmo = ref heavyWeaponAmmoComponent.maxAmmo;
                ref var timer = ref heavyWeaponAmmoComponent.timer;
                ref var recoveryTime = ref heavyWeaponAmmoComponent.recoveryTime;

                if (realAmmo < maxAmmo)
                {
                    timer -= Time.deltaTime;
                    if (timer < 0)
                    {
                        realAmmo++;
                        timer = recoveryTime;
                    }
                }

                if (realAmmo == 0)
                    entity.Get<HeavyWeaponBlockComponent>().timer = timer;

            }
        }
    }
}
