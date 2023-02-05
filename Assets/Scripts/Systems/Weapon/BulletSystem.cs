using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class BulletSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BulletComponent, TransformComponent> bulletsFilter = null;

        public void Run()
        {
            foreach (var i in bulletsFilter)
            {
                ref var bulletComponent = ref bulletsFilter.Get1(i);
                ref var transformComponent = ref bulletsFilter.Get2(i);

                ref var speed = ref bulletComponent.speed;
                ref var transform = ref transformComponent.transform;

                transform.position += transform.up * speed * Time.deltaTime;
            }
        }
    }
}
