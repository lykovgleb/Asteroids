using Leopotam.Ecs;
using System;

namespace AsteroidsEcs
{
    sealed class UIPositionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, TransformComponent> positionFilter = null;
        private readonly EcsFilter<UIPositionComponent> UIFilter = null;

        string coordinates;

        public void Run()
        {
            foreach (var i in positionFilter)
            {
                ref var transformComponent = ref positionFilter.Get2(i);

                ref var transform = ref transformComponent.transform;

                coordinates = string.Format("{0:N2}", transform.position.x) + " | " + string.Format("{0:N2}", transform.position.y);
            }

            foreach (var i in UIFilter)
            {
                ref var UIComponent = ref UIFilter.Get1(i);

                UIComponent.text.text = "Position - " + coordinates;
            }
        }
    }
}
