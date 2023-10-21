using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damageAmount = 1;
    public bool canSlow;

    private void Start()
    {
        Destroy(gameObject, 10.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Zombies")
        {
            ZombieController zombie = other.GetComponent<ZombieController>();

            if (zombie != null)
            {
                if (canSlow)
                {
                    zombie.SlowedDown();
                }

                zombie.GetDamage(damageAmount);
            }
            Destroy(gameObject, 0.1f);
        }
    }
}
