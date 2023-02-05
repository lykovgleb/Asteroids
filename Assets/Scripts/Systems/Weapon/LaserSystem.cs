using Leopotam.Ecs;
using NTC.Global.Pool;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class LaserSystem : IEcsRunSystem
    {
        private readonly EcsFilter<LaserComponent, TransformComponent> laserFilter = null;

        public void Run()
        {
            foreach (var i in laserFilter)
            {
                ref var laserComponent = ref laserFilter.Get1(i);
                ref var transformComponent = ref laserFilter.Get2(i);

                ref var timer = ref laserComponent.timer;
                timer -= Time.deltaTime;

                if (timer <=
                    0)
                {
                    NightPool.Despawn(transformComponent.transform.gameObject);
                    timer = laserComponent.time;
                }
            }
        }
    }
}
