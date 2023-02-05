using AsteroidsEcs;
using Leopotam.Ecs;
using UnityEngine;


public class DestoryWithLaserTrigger : MonoBehaviour
{
    private readonly string enemy = "Enemy";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemy))
        {
            collision.GetComponent<EntityReferens>().entity.Get<DestroyEvent>();
        }
    }
}
