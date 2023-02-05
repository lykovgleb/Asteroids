using Leopotam.Ecs;

namespace AsteroidsEcs
{
    sealed class GameOverSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GameOverEvent> gameOverFilter = null;
        private readonly EcsFilter<PlayerTag, PlayerMovementComponent, LightWeaponComponent, HeavyWeaponComponent> playerFilter = null;

        public void Run()
        {
            foreach (var i in gameOverFilter)
            {
                foreach (var j in playerFilter)
                {
                    ref var entity = ref playerFilter.GetEntity(j);
                    ref var playerMovementComponent = ref playerFilter.Get2(j);
                    ref var lightWeaponComponent = ref playerFilter.Get3(j);
                    ref var heavyWeaponComponent = ref playerFilter.Get4(j);

                    entity.Get<InputBlockComponent>();
                    playerMovementComponent.moveForward = 0;
                    lightWeaponComponent.isAttack = false;
                    heavyWeaponComponent.isAttack = false;
                }
            }
        }
    }
}
