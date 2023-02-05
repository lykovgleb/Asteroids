using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class ReplaceSpawnAsteroidSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<AsteroidTag, SpawnEvent, TransformComponent, DirectionComponent>.
            Exclude<DebrisTag> spawnedAsteroidFilter = null;
        private readonly EcsFilter<ScreenSizeComponent> screenSizeFilter = null;

        private Vector2 screenSize;

        public void Init()
        {
            foreach (var i in screenSizeFilter)
            {
                ref var screenSizeComponent = ref screenSizeFilter.Get1(i);
                screenSize = screenSizeComponent.upperRight;
            }
        }

        public void Run()
        {
            foreach (var i in spawnedAsteroidFilter)
            {
                ref var transformComponent = ref spawnedAsteroidFilter.Get3(i);
                ref var directionComponent = ref spawnedAsteroidFilter.Get4(i);

                ref var transform = ref transformComponent.transform;
                ref var direction = ref directionComponent.direction;

                transform.position = Random.insideUnitCircle.normalized * screenSize.magnitude;
                var target = Random.insideUnitCircle * screenSize.y;
                direction = new Vector2(target.x - transform.position.x, target.y - transform.position.y).normalized;
            }
        }
    }
}
