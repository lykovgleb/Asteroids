using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class UISpeedSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, MovableComponent> playerFilter = null;
        private readonly EcsFilter<UISpeedComponent> UIFilter = null;

        string speed;

        public void Run()
        {
            foreach (var i in playerFilter)
            {
                ref var movableComponent = ref playerFilter.Get2(i);

                ref var rigidbody = ref movableComponent.rigidbody;

                speed = string.Format("{0:N2}", rigidbody.velocity.magnitude);
            }

            foreach (var i in UIFilter)
            {
                ref var UIComponent = ref UIFilter.Get1(i);

                UIComponent.text.text = speed + " Units/Sec";
            }
        }
    }
}
