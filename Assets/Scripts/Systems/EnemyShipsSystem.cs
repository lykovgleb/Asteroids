using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class EnemyShipsSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<EnemyTag, TransformComponent, MovableComponent> enemyShipsFilter = null;
        private readonly EcsFilter<PlayerTag, TransformComponent> playerFilter = null;

        private Transform player;

        public void Init()
        {
            foreach (var i in playerFilter)
            {
                ref var playerTransform = ref playerFilter.Get2(i);
                player = playerTransform.transform;
            }
        }

        public void Run()
        {
            foreach (var i in enemyShipsFilter)
            {
                ref var transformComponent = ref enemyShipsFilter.Get2(i);
                ref var movableComponent = ref enemyShipsFilter.Get3(i);

                ref var rigidbody = ref movableComponent.rigidbody;
                ref var speed = ref movableComponent.speed;
                ref var transform = ref transformComponent.transform;

                var direction = (player.position - transform.position).normalized;
                rigidbody.AddForce(direction * speed);

            }
        }
    }
}
