using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class ReplaceSpawnEnemyShipSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<EnemyTag, SpawnEvent, TransformComponent> spawnedEnemyShipFilter = null;
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
            foreach (var i in spawnedEnemyShipFilter)
            {
                ref var transformComponent = ref spawnedEnemyShipFilter.Get3(i);

                ref var transform = ref transformComponent.transform;

                transform.position = Random.insideUnitCircle.normalized * screenSize.magnitude;
            }
        }
    }
}
