using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Enums.Zombies type;
    public float moveSpeed = 0.5f;
    public float slowedMoveSpeed = 0.3f;

    public float slowTime = 3.0f;

    private float remainingSlow;

    public bool hasHat;

    public int zombieHealth;

    private int zombieMaxHealth;
    public int hatHealth;

    private int hatMaxHealth;

    private SpriteRenderer SR;

    [SerializeField] private GameObject hat;

    private Rigidbody2D RB;

    private SpriteRenderer hatSR;
    [SerializeField] private Sprite zombieChangeSprite;
    [SerializeField] private Sprite hatChangeSprite;

    [SerializeField] private AudioSource zombieHitSound;
    [SerializeField] private AudioSource zombieDeathSound;

    [SerializeField] private AudioSource hatHitSound;
    [SerializeField] private AudioSource hatDropSound;

    private bool soundPlayed;

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        hatSR = hat.GetComponent<SpriteRenderer>();
        RB = GetComponent<Rigidbody2D>();
        RB.velocity = new Vector2(-moveSpeed, 0.0f);
        zombieMaxHealth = zombieHealth;
        hatMaxHealth = hatHealth;
        soundPlayed = false;

    }
    private void Update()
    {

        if (remainingSlow <= 0f)
        {
            BackToNormal();
        }
        remainingSlow -= Time.deltaTime;
        if (hasHat)
        {
            if (hatHealth <= 0)
            {
                hatDropSound.Play();

                hasHat = false;
                Destroy(hat);
            }
            else if (hatHealth <= hatMaxHealth / 2)
            {
                hatSR.sprite = hatChangeSprite;
            }

        }
        if (zombieHealth <= 0)
        {
            if (!soundPlayed)
            {
                zombieDeathSound.Play();
                soundPlayed = true;
            }

            Destroy(gameObject, 0.1f);
        }
        else if (zombieHealth <= zombieMaxHealth / 2 && zombieChangeSprite != null)
        {
            SR.sprite = zombieChangeSprite;
        }
    }
    public void GetDamage(int damageAmount)
    {
        if (hasHat)
        {
            hatHitSound.Play();
            hatHealth -= damageAmount;
        }
        else
        {
            zombieHitSound.Play();
            zombieHealth -= damageAmount;
        }
    }

    public void SlowedDown()
    {
        remainingSlow = slowTime;
        RB.velocity = new Vector2(-slowedMoveSpeed, 0.0f);
        SR.color = new Color(0, 0.5f, 1, 1);
        if (hasHat)
        {
            hatSR.color = new Color(0, 0.5f, 1, 1);
        }
    }

    public void BackToNormal()
    {
        RB.velocity = new Vector2(-moveSpeed, 0.0f);
        SR.color = new Color(1, 1, 1, 1);
        if (hasHat)
        {
            hatSR.color = new Color(1, 1, 1, 1);
        }
    }
}
