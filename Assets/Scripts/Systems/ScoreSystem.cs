using Leopotam.Ecs;

namespace AsteroidsEcs
{
    sealed class ScoreSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<DestroyEvent, PointsComponent> scoreFilter = null;

        private EcsEntity scoreEntity;

        public void Init()
        {
            scoreEntity = _world.NewEntity();
            scoreEntity.Get<ScoreComponent>().score = 0;
        }

        public void Run()
        {
            foreach (var i in scoreFilter)
            {
                ref var pointsComponent = ref scoreFilter.Get2(i);

                scoreEntity.Get<ScoreComponent>().score += pointsComponent.points;
            }
        }
    }
}
