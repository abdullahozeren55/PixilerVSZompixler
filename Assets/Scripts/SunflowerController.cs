using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerController : MonoBehaviour
{
    [SerializeField] private GameObject sunPrefab;

    [SerializeField] private GameObject sunCreatePoint;

    [SerializeField] private float minTimeToSpawnSun;

    [SerializeField] private float maxTimeToSpawnSun;

    private float nextSpamTime;
    void Start()
    {
        nextSpamTime = Time.time + Random.Range(minTimeToSpawnSun, maxTimeToSpawnSun);
    }
    void Update()
    {
        if (Time.time >= nextSpamTime)
        {
            Instantiate(sunPrefab, sunCreatePoint.transform.position, Quaternion.identity);

            nextSpamTime = Time.time + Random.Range(minTimeToSpawnSun, maxTimeToSpawnSun);
        }
    }
}
