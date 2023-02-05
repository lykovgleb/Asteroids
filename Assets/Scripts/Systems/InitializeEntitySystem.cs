using Leopotam.Ecs;

namespace AsteroidsEcs
{
    sealed class InitializeEntitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<InitializeEntityRequest> initFilter = null;

        public void Run()
        {
            foreach (var i in initFilter)
            {
                ref var entity = ref initFilter.GetEntity(i);
                ref var request = ref initFilter.Get1(i);

                request.entityReferens.entity = entity;
                entity.Get<SpawnEvent>();
            }
        }
    }
}
