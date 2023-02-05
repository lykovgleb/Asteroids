using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class UIAngleSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, TransformComponent> rotationFilter = null;
        private readonly EcsFilter<UIAngleComponent> UIFilter = null;

        string angle;

        public void Run()
        {
            foreach (var i in rotationFilter)
            {
                ref var transformComponent = ref rotationFilter.Get2(i);

                ref var transform = ref transformComponent.transform;

                angle = string.Format("{0:N2}", Vector3.Angle(Vector3.up, transform.up));
            }

            foreach (var i in UIFilter)
            {
                ref var UIComponent = ref UIFilter.Get1(i);

                UIComponent.text.text = angle + "°";
            }
        }
    }
}
