using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;


namespace AsteroidsEcs
{
    public class EcsStartUp : MonoBehaviour
    {
        private EcsWorld world;
        private EcsSystems systems;

        private void Start()
        {
            world = new EcsWorld();
            systems = new EcsSystems(world);

            systems.ConvertScene();

            AddSystems();
            AddOneFrames();

            systems.Init();
        }

        private void AddSystems()
        {
            systems. //Configuration of frame
                Add(new ScreenSizeSystem()).
                Add(new InputSystem()).
                //Spawn new objects
                Add(new SpawnSystem()).
                Add(new HeavyWeaponSystem()).
                Add(new HeavyWeaponBlockSystem()).
                Add(new HeavyWeaponAmmoSystem()).
                Add(new LightWeaponSystem()).
                Add(new LightWeaponBlockSystem()).
                Add(new InitializeEntitySystem()).
                Add(new ReplaceSpawnDebrisSystem()).
                Add(new ReplaceSpawnEnemyShipSystem()).
                Add(new ReplaceSpawnAsteroidSystem()).
                //Movement and timers
                Add(new PlayerMovementSystem()).
                Add(new ScreenWrapSystem()).
                Add(new BulletSystem()).
                Add(new LaserSystem()).
                Add(new EnemyShipsSystem()).
                Add(new AsteroidsSystem()).
                //Results
                Add(new DebrisAsteroidSystem()).
                Add(new OutOfBoundsSystem()).
                Add(new ScoreSystem()).
                Add(new GameOverSystem()).
                Add(new RestartGameSystem()).
                Add(new DestroySystem()).
                //UI
                Add(new UIPositionSystem()).
                Add(new UIAngleSystem()).
                Add(new UISpeedSystem()).
                Add(new UIHeavyWeaponSystem()).
                Add(new UIScoreSystem()).
                Add(new UIRestartButtonSystem());
        }

        private void AddOneFrames()
        {
            systems.
                OneFrame<SpawnEvent>().
                OneFrame<DestroyEvent>().
                OneFrame<DebrisEvent>().
                OneFrame<GameOverEvent>().
                OneFrame<RestartEvent>().
                OneFrame<InitializeEntityRequest>();
        }

        private void Update()
        {
            systems.Run();
        }

        private void OnDestroy()
        {
            systems.Destroy();
            systems = null;
            world.Destroy();
            world = null;
        }
    }
}
