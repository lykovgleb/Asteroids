using Leopotam.Ecs;
using NTC.Global.Pool;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class SpawnSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<SpawnComponent> spawnFilter = null;

        public void Init()
        {
            foreach (var i in spawnFilter)
            {
                ref var spawnComponent = ref spawnFilter.Get1(i);

                ref var timer = ref spawnComponent.timer;
                ref var spawnTime = ref spawnComponent.spawnTime;

                timer = spawnTime;
            }
        }

        public void Run()
        {

            foreach (var i in spawnFilter)
            {
                ref var spawnComponent = ref spawnFilter.Get1(i);

                ref var timer = ref spawnComponent.timer;
                ref var spawnTime = ref spawnComponent.spawnTime;
                ref var prefab = ref spawnComponent.prefab;
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    NightPool.Spawn(prefab, prefab.transform.position, prefab.transform.rotation);
                    timer = spawnTime;
                }
            }
        }
    }
}
