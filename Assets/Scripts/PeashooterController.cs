using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeashooterController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float shootingCooldown;

    [SerializeField] private GameObject mouth;
    private float lastShootingTime;

    [SerializeField] private LayerMask whatIsZombies;

    void Start()
    {
        lastShootingTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastShootingTime + shootingCooldown)
        {
            RaycastHit2D hit = Physics2D.Raycast(mouth.transform.position, Vector2.right, Mathf.Infinity, whatIsZombies);

            if (hit.collider != null)
            {
                ShootTheBullet();
                lastShootingTime = Time.time;
            }
        }
    }


    private void ShootTheBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, mouth.transform.position, Quaternion.identity);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(bulletSpeed, 0.0f);
    }
}
