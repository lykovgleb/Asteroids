using Leopotam.Ecs;
using NTC.Global.Pool;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class HeavyWeaponSystem : IEcsRunSystem
    {
        private readonly EcsFilter<HeavyWeaponComponent, TransformComponent, HeavyWeaponAmmoComponent>.
            Exclude<HeavyWeaponBlockComponent> heavyWeaponFilter = null;

        public void Run()
        {
            foreach (var i in heavyWeaponFilter)
            {
                ref var entity = ref heavyWeaponFilter.GetEntity(i);
                ref var heavyWeaponComponent = ref heavyWeaponFilter.Get1(i);
                ref var transformComponent = ref heavyWeaponFilter.Get2(i);
                ref var heavyWeaponAmmoComponent = ref heavyWeaponFilter.Get3(i);

                ref var prefab = ref heavyWeaponComponent.prefab;
                ref var isAttack = ref heavyWeaponComponent.isAttack;
                ref var transform = ref transformComponent.transform;
                ref var ammo = ref heavyWeaponAmmoComponent.realAmmo;


                if (isAttack)
                {
                    ammo--;
                    NightPool.Spawn(prefab, transform.position + transform.up * 15, transform.rotation);
                    entity.Get<HeavyWeaponBlockComponent>().timer = 1.5f;
                }

            }
        }
    }
}
