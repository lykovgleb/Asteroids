using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class ReplaceSpawnDebrisSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AsteroidTag, DebrisTag, SpawnEvent, DirectionComponent>.
            Exclude<DebrisComponent> spawnedDebrisFilter = null;

        public void Run()
        {
            foreach (var i in spawnedDebrisFilter)
            {
                ref var directionComponent = ref spawnedDebrisFilter.Get4(i);

                ref var direction = ref directionComponent.direction;

                direction = Random.insideUnitCircle.normalized;
            }
        }
    }
}
