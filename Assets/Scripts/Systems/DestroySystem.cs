using Leopotam.Ecs;
using NTC.Global.Pool;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class DestroySystem : IEcsRunSystem
    {
        private readonly EcsFilter<DestroyEvent, TransformComponent> destroyFilter = null;

        public void Run()
        {
            foreach (var i in destroyFilter)
            {
                ref var transformComponent = ref destroyFilter.Get2(i);

                NightPool.Despawn(transformComponent.transform.gameObject);
            }
        }
    }
}
