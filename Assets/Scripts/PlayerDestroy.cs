using AsteroidsEcs;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;


public class PlayerDestroy : MonoBehaviour
{
    private readonly string enemy = "Enemy";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemy))
        {
            WorldHandler.GetWorld().NewEntity().Get<GameOverEvent>();
        }
    }
}


