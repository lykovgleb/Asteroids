using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class UIScoreSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<GameOverEvent> gameOverFilter = null;
        private readonly EcsFilter<RestartEvent> restartFilter = null;
        private readonly EcsFilter<UIScoreComponent, UIPannelComponent> UIFilter = null;
        private readonly EcsFilter<ScoreComponent> scoreFilter = null;


        private EcsEntity scoreEntity;

        public void Init()
        {
            foreach (var i in UIFilter)
            {
                ref var pannelComponent = ref UIFilter.Get2(i);

                pannelComponent.pannel.SetActive(false);
            }

            foreach (var i in scoreFilter)
            {
                ref var entity = ref scoreFilter.GetEntity(i);

                scoreEntity = entity;
            }
        }

        public void Run()
        {
            foreach (var i in gameOverFilter)
            {
                foreach (var j in UIFilter)
                {
                    ref var UIComponent = ref UIFilter.Get1(j);
                    ref var pannelComponent = ref UIFilter.Get2(j);

                    pannelComponent.pannel.gameObject.SetActive(true);

                    UIComponent.text.text = "Score: " + scoreEntity.Get<ScoreComponent>().score;
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
