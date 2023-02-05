using AsteroidsEcs;
using Leopotam.Ecs;
using UnityEngine;

public class DestroyWithBulletTrigger : MonoBehaviour
{
    private readonly string enemy = "Enemy";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemy))
        {

            if (collision.GetComponent<EntityReferens>().entity.Has<DebrisComponent>())
            {
                collision.GetComponent<EntityReferens>().entity.Get<DebrisEvent>();
            }

            collision.GetComponent<EntityReferens>().entity.Get<DestroyEvent>();
            GetComponent<EntityReferens>().entity.Get<DestroyEvent>();
        }
    }
}


