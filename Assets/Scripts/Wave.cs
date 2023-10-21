using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;

public class Wave
{

    public float startTime;
    List<ZombieSpawner> spawners;
    Enums.Zombies[] zombies;
    public Wave(List<ZombieSpawner> spawners, float startTime, params Enums.Zombies[] zombies)
    {
        this.spawners = spawners;
        this.zombies = zombies;
        this.startTime = startTime;
    }
    public async Task<List<GameObject>> StartWave()
    {
        List<GameObject> tempZombies = new List<GameObject>();
        foreach (var item in zombies)
        {
            await Task.Delay(1000);
            var random = new System.Random();
            tempZombies.Add(spawners[random.Next(spawners.Count)].Spawn(item));
        }
        return tempZombies;
    }
}
