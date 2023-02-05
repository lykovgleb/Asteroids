using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class ScreenWrapSystem : IEcsRunSystem, IEcsInitSystem
    {
        public readonly EcsFilter<PlayerTag, TransformComponent> playerFilter = null;
        public readonly EcsFilter<ScreenSizeComponent> screenFilter = null;

        private Vector2 upperRight;
        private Vector2 lowerLeft;

        private float buffer = 1.0f;
        private float playerVisualArea = 0.5f;

        public void Init()
        {
            foreach (var i in screenFilter)
            {
                ref var screenSizeComponent = ref screenFilter.Get1(i);

                upperRight = screenSizeComponent.upperRight;
                lowerLeft = screenSizeComponent.lowerLeft;
            }
        }

        public void Run()
        {
            foreach (var i in playerFilter)
            {
                ref var transformComponent = ref playerFilter.Get2(i);

                ref var transform = ref transformComponent.transform;

                if (transform.position.x > upperRight.x + buffer)
                    transform.position = new Vector3(lowerLeft.x - playerVisualArea, transform.position.y, 0);

                if (transform.position.x < lowerLeft.x - buffer)
                    transform.position = new Vector3(upperRight.x + playerVisualArea, transform.position.y, 0);

                if (transform.position.y > upperRight.y + buffer)
                    transform.position = new Vector3(transform.position.x, lowerLeft.y - playerVisualArea, 0);

                if (transform.position.y < lowerLeft.y - buffer)
                    transform.position = new Vector3(transform.position.x, upperRight.y + playerVisualArea, 0);
            }
        }
    }
}
