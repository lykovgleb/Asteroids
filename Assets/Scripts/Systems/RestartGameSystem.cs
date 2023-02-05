using Leopotam.Ecs;

namespace AsteroidsEcs
{
    sealed class RestartGameSystem : IEcsRunSystem
    {
        private readonly EcsFilter<RestartEvent> gameOverFilter = null;
        private readonly EcsFilter<PlayerTag, InputBlockComponent> playerFilter = null;
        private readonly EcsFilter<TransformComponent>.Exclude<PlayerTag> enemyFilter = null;
        private readonly EcsFilter<ScoreComponent> scoreFilter = null;

        public void Run()
        {
            foreach (var i in gameOverFilter)
            {
                foreach (var j in enemyFilter)
                {
                    ref var entity = ref enemyFilter.GetEntity(j);

                    entity.Del<PointsComponent>();
                    entity.Get<DestroyEvent>();
                }

                foreach (var j in playerFilter)
                {
                    ref var entity = ref playerFilter.GetEntity(j);

                    entity.Del<InputBlockComponent>();
                }

                foreach (var j in scoreFilter)
                {
                    ref var scoreComponent = ref scoreFilter.Get1(j);

                    scoreComponent.score = 0;
                }
            }
        }
    }
}
