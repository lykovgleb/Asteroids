using Leopotam.Ecs;

namespace AsteroidsEcs
{
    sealed class OutOfBoundsSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<TransformComponent>.Exclude<PlayerTag> transformFilter = null;
        private readonly EcsFilter<ScreenSizeComponent> ScreenSizeFilter = null;

        private float playgroundSize;

        public void Init()
        {
            foreach (var i in ScreenSizeFilter)
            {
                ref var ScreenSizeComponent = ref ScreenSizeFilter.Get1(i);

                playgroundSize = ScreenSizeComponent.upperRight.magnitude + 1;
            }
        }

        public void Run()
        {
            foreach (var i in transformFilter)
            {
                ref var entity = ref transformFilter.GetEntity(i);
                ref var transformComponent = ref transformFilter.Get1(i);

                ref var transform = ref transformComponent.transform;

                if (transform.position.magnitude > playgroundSize)
                {
                    entity.Del<PointsComponent>();
                    entity.Get<DestroyEvent>();
                }
            }
        }
    }
}
