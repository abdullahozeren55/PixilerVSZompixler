using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sunPrefab;
    [SerializeField] private float startTimeRange = 5.0f;
    [SerializeField] private float endTimeRange = 9.0f;
    [SerializeField] private float sunDropSpeed = 1.5f;
    [SerializeField] private float sunStopStartRange = 3.0f;
    [SerializeField] private float sunStopEndRange = 9.0f;

    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(startTimeRange, endTimeRange);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GameObject sun = Instantiate(sunPrefab, this.transform);
            sun.transform.position = new Vector2(Random.Range(-10.0f, 10.0f), sun.transform.position.y);
            Rigidbody2D RB = (sun.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D);
            RB.gravityScale = 0.0f;
            RB.velocity = new Vector2(0.0f, -sunDropSpeed);
            StopSun(sun);
            timer = Random.Range(startTimeRange, endTimeRange);
        }
    }

    async void StopSun(GameObject sun)
    {
        await Task.Delay((int)(Random.Range(sunStopStartRange, sunStopEndRange) * 1000));
        if (!sun.IsDestroyed())
        {
            sun.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
