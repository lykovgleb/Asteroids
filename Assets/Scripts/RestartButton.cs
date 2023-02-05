using AsteroidsEcs;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class RestartButton : MonoBehaviour
{
    public void OnRestartButtonClick()
    {
        WorldHandler.GetWorld().NewEntity().Get<RestartEvent>();
    }
}
