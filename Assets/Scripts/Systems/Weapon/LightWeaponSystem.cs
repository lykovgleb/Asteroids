using Leopotam.Ecs;
using NTC.Global.Pool;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

namespace AsteroidsEcs
{
    sealed class LightWeaponSystem : IEcsRunSystem
    {
        private readonly EcsFilter<LightWeaponComponent, TransformComponent>.
            Exclude<LightWeaponBlockComponent> lightWeaponFilter = null;

        public void Run()
        {
            foreach (var i in lightWeaponFilter)
            {
                ref var entity = ref lightWeaponFilter.GetEntity(i);
                ref var lightWeaponComponent = ref lightWeaponFilter.Get1(i);
                ref var transformComponent = ref lightWeaponFilter.Get2(i);

                ref var bullet = ref lightWeaponComponent.bullet;
                ref var isAttack = ref lightWeaponComponent.isAttack;
                ref var transform = ref transformComponent.transform;


                if (isAttack)
                {
                    NightPool.Spawn(bullet, transform.position, transform.rotation);
                    entity.Get<LightWeaponBlockComponent>().delay = 0.5f;
                }

            }
        }
    }
}
