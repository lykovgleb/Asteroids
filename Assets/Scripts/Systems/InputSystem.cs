using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsEcs
{
    sealed class InputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, PlayerMovementComponent, LightWeaponComponent, HeavyWeaponComponent>.
            Exclude<InputBlockComponent> playerInputFilter = null;

        private float forward;
        private float rotate;
        private bool isLightAttackInput;
        private bool isHeavyAttackInput;

        public void Run()
        {
            SetDirection();
            isAttack();
            foreach (var i in playerInputFilter)
            {
                ref var movementComponent = ref playerInputFilter.Get2(i);
                ref var lightWeaponComponent = ref playerInputFilter.Get3(i);
                ref var heavyWeaponComponent = ref playerInputFilter.Get4(i);

                ref var rotation = ref movementComponent.rotation;
                ref var rotationStep = ref movementComponent.rotationStep;
                ref var moveForward = ref movementComponent.moveForward;
                ref var isLightAttack = ref lightWeaponComponent.isAttack;
                ref var isHeavyAttack = ref heavyWeaponComponent.isAttack;

                rotation += rotate * rotationStep;
                if (forward >= 0) moveForward = forward;
                isLightAttack = isLightAttackInput;
                isHeavyAttack = isHeavyAttackInput;
            }
        }

        private void isAttack()
        {
            isLightAttackInput = Input.GetKey(KeyCode.Space);
            isHeavyAttackInput = Input.GetKey(KeyCode.E);
        }

        private void SetDirection()
        {
            forward = Input.GetAxis("Vertical");
            rotate = Input.GetAxis("Horizontal");
        }
    }
}
