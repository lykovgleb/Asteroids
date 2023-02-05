using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class LightWeaponBlockSystem : IEcsRunSystem
    {
        private readonly EcsFilter<LightWeaponBlockComponent> lightWeaponBlockFilter = null;

        public void Run()
        {
            foreach (var i in lightWeaponBlockFilter)
            {
                ref var entity = ref lightWeaponBlockFilter.GetEntity(i);
                ref var lightWeaponBlockComponent = ref lightWeaponBlockFilter.Get1(i);

                ref var delay = ref lightWeaponBlockComponent.delay;

                delay -= Time.deltaTime;

                if (delay < 0)
                {
                    entity.Del<LightWeaponBlockComponent>();
                }
            }
        }
    }
}
