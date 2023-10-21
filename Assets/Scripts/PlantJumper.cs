using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantJumper : MonoBehaviour
{

    private SpriteRenderer SR;

    private bool hasJumped;

    private ZombieController zombieController;

    private PlantEater plantEater;

    [SerializeField] private Sprite jumpSprite;

    [SerializeField] private Sprite walkSprite;

    [SerializeField] private float timer;

    [SerializeField] private LayerMask whatIsPlants;

    [SerializeField] private AudioSource jumpSound;

    private bool soundPlayed;

    private float remainingTime;
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        zombieController = GetComponent<ZombieController>();
        plantEater = GetComponent<PlantEater>();
        remainingTime = 0.0f;
        hasJumped = false;
        soundPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0 && hasJumped)
        {
            WalkState();
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, 1.0f, whatIsPlants);

        if (hit.collider != null)
        {
            if (!soundPlayed)
            {
                jumpSound.Play();
                soundPlayed = true;
            }

            remainingTime = timer;
            transform.gameObject.tag = "Untouchable";
            transform.gameObject.layer = LayerMask.NameToLayer("Uncollisionable");
            SR.sprite = jumpSprite;
            hasJumped = true;
            whatIsPlants = 0;
        }
    }

    private void WalkState()
    {
        transform.gameObject.tag = "Zombies";
        transform.gameObject.layer = LayerMask.NameToLayer("Zombies");
        SR.sprite = walkSprite;
        zombieController.moveSpeed = zombieController.moveSpeed / 2;
        zombieController.slowedMoveSpeed = zombieController.slowedMoveSpeed / 2;
        plantEater.enabled = true;
        this.gameObject.GetComponent<PlantJumper>().enabled = false;
    }
}
