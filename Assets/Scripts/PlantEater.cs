using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEater : MonoBehaviour
{

    public int eatDamage;

    public float eatingSpeed;

    private float timeCounter;

    private ZombieController zombieController;

    private PlantHealthController plantHealthController;

    private Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        timeCounter = 0.0f;
        zombieController = GetComponent<ZombieController>();
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (plantHealthController != null)
        {
            timeCounter += Time.deltaTime;
            if (timeCounter >= eatingSpeed)
            {
                plantHealthController.TakeDamage(eatDamage);
                timeCounter = 0.0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Plants")
        {
            RB.velocity = new Vector2(0.0f, 0.0f);
            timeCounter = 0.0f;

            plantHealthController = other.gameObject.GetComponent<PlantHealthController>();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Plants")
        {

            RB.velocity = new Vector2(-GetComponent<ZombieController>().moveSpeed, 0.0f);
            plantHealthController = null;
        }

    }
}
