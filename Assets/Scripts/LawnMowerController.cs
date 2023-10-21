using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMowerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private AudioSource lawnMowerSound;

    private bool soundPlayed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundPlayed = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Zombies")
        {
            if (!soundPlayed)
            {
                lawnMowerSound.Play();
                soundPlayed = true;
            }
            Destroy(gameObject, 3.0f);
            rb.velocity = new Vector2(9.0f, 0.0f);

            ZombieController zombie = other.gameObject.GetComponent<ZombieController>();

            if (zombie != null)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
