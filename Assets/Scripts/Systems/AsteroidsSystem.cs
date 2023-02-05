using Leopotam.Ecs;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class AsteroidsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AsteroidTag, TransformComponent, MovableComponent, DirectionComponent> asteroidsFilter = null;

        public void Run()
        {
            foreach (var i in asteroidsFilter)
            {
                ref var transformComponent = ref asteroidsFilter.Get2(i);
                ref var movableComponent = ref asteroidsFilter.Get3(i);
                ref var directionComponent = ref asteroidsFilter.Get4(i);

                ref var rigidbody = ref movableComponent.rigidbody;
                ref var speed = ref movableComponent.speed;
                ref var transform = ref transformComponent.transform;
                ref var direction = ref directionComponent.direction;

                rigidbody.MovePosition(rigidbody.position + speed * Time.deltaTime * direction);
            }
        }
    }
}
