using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class ScreenSizeSystem : IEcsInitSystem
    {
        private readonly EcsFilter<ScreenSizeComponent> cameraFilter = null;

        public void Init()
        {
            foreach (var i in cameraFilter)
            {
                ref var screenSizeComponent = ref cameraFilter.Get1(i);

                ref var camera = ref screenSizeComponent.camera;
                ref var min = ref screenSizeComponent.lowerLeft;
                ref var max = ref screenSizeComponent.upperRight;

                min = camera.ViewportToWorldPoint(new Vector2(0, 0));
                max = camera.ViewportToWorldPoint(new Vector2(1, 1));
            }
        }
    }
}
