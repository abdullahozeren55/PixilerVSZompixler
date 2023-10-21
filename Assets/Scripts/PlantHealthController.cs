using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHealthController : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private Sprite spriteToReplace;

    private SpriteRenderer SR;

    private float maxHealth;

    [SerializeField] private AudioSource getDamageSound;
    void Start()
    {
        maxHealth = health;
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int dmgAmount)
    {
        getDamageSound.Play();
        health -= dmgAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else if (health <= maxHealth / 2 && spriteToReplace != null)
        {
            SR.sprite = spriteToReplace;
        }

    }
}
