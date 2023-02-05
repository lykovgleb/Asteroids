using Leopotam.Ecs;
using NTC.Global.Pool;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class DebrisAsteroidSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AsteroidTag, DebrisEvent, DebrisComponent, TransformComponent> debrisFilter = null;

        public void Run()
        {
            foreach (var i in debrisFilter)
            {
                ref var debrisComponent = ref debrisFilter.Get3(i);
                ref var transformComponent = ref debrisFilter.Get4(i);

                ref var transform = ref transformComponent.transform;

                var n = Random.Range(2, 5);
                for (int j = 0; j < n; j++)
                {
                    NightPool.Spawn(debrisComponent.debris, transform.position, transform.rotation);
                }
            }
        }
    }
}
