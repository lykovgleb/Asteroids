using Leopotam.Ecs;

namespace AsteroidsEcs
{
    sealed class UIHeavyWeaponSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, HeavyWeaponAmmoComponent> playerFilter = null;
        private readonly EcsFilter<UIHeavyWeaponComponent> UIFilter = null;

        int maxQuantity;
        int quantity;
        float time;

        public void Run()
        {
            foreach (var i in playerFilter)
            {
                ref var heavyWeaponAmmoComponent = ref playerFilter.Get2(i);

                maxQuantity = heavyWeaponAmmoComponent.maxAmmo;
                quantity = heavyWeaponAmmoComponent.realAmmo;
                time = heavyWeaponAmmoComponent.timer;
            }

            foreach (var i in UIFilter)
            {
                ref var UIComponent = ref UIFilter.Get1(i);

                UIComponent.text.text = $"{quantity}/{maxQuantity} ({(int)time}s)";
            }
        }
    }
}
