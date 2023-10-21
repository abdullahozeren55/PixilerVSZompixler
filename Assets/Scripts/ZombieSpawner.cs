using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Unity.Mathematics;

public class ZombieSpawner : MonoBehaviour
{

    public List<GameObject> zombieTypes;
    public GameObject Spawn(Enums.Zombies zombie)
    {
        return Instantiate(zombieTypes.FirstOrDefault(x => x.GetComponent<ZombieController>().type == zombie), transform.position, Quaternion.identity);

    }
}
