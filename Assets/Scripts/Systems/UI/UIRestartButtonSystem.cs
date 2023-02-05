using Leopotam.Ecs;

namespace AsteroidsEcs
{
    sealed class UIRestartButtonSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<GameOverEvent> gameOverFilter = null;
        private readonly EcsFilter<RestartEvent> restartFilter = null;
        private readonly EcsFilter<UIRestartButtonTag, UIPannelComponent> UIFilter = null;

        public void Init()
        {
            foreach (var i in UIFilter)
            {
                ref var pannelComponent = ref UIFilter.Get2(i);

                pannelComponent.pannel.SetActive(false);
            }
        }

        public void Run()
        {
            foreach (var i in gameOverFilter)
            {
                foreach (var j in UIFilter)
                {
                    ref var pannelComponent = ref UIFilter.Get2(j);

                    pannelComponent.pannel.gameObject.SetActive(true);
                }
            }

            foreach (var i in restartFilter)
            {
                foreach (var j in UIFilter)
                {
                    ref var pannelComponent = ref UIFilter.Get2(j);

                    pannelComponent.pannel.gameObject.SetActive(false);
                }
            }
        }
    }
}
