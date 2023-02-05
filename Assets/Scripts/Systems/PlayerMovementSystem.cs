using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TransformComponent, MovableComponent, PlayerMovementComponent> movableFilter = null;

        public void Run()
        {
            foreach (var i in movableFilter)
            {
                ref var modelTransformComponent = ref movableFilter.Get1(i);
                ref var movableComponent = ref movableFilter.Get2(i);
                ref var movementComponent = ref movableFilter.Get3(i);

                ref var rotation = ref movementComponent.rotation;

                ref var transform = ref modelTransformComponent.transform;
                ref var rigidbody = ref movableComponent.rigidbody;
                ref var speed = ref movableComponent.speed;
                ref var moveForward = ref movementComponent.moveForward;

                rigidbody.AddForce(moveForward * speed * transform.up);
                transform.rotation = Quaternion.Euler(0, 0, rotation);
            }
        }
    }
}
