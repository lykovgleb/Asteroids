using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class HeavyWeaponBlockSystem : IEcsRunSystem
    {
        private readonly EcsFilter<HeavyWeaponBlockComponent> heavyWeaponBlockFilter = null;

        public void Run()
        {
            foreach (var i in heavyWeaponBlockFilter)
            {
                ref var entity = ref heavyWeaponBlockFilter.GetEntity(i);
                ref var heavyWeaponBlockComponent = ref heavyWeaponBlockFilter.Get1(i);

                ref var timer = ref heavyWeaponBlockComponent.timer;

                timer -= Time.deltaTime;

                if (timer < 0)
                {
                    entity.Del<HeavyWeaponBlockComponent>();
                }
            }
        }
    }
}
