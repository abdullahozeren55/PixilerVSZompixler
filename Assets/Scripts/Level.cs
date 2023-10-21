using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Level
{

    public List<GameObject> zombies = new List<GameObject>();
    public List<Wave> waves;
    public bool levelFinished = false;

    public Level(List<Wave> waves)
    {
        this.waves = waves;
    }

    public void startLevel()
    {
        for (int i = 0; i < waves.Count; i++)
        {
            StartWaveX(waves[i], i);
        }
    }

    private async void StartWaveX(Wave wave, int i)
    {
        await Task.Delay((int)wave.startTime * 1000);
        zombies.AddRange(await wave.StartWave());
        Debug.Log("Starting wave " + i);
        if (i == waves.Count - 1)
        {
            levelFinished = true;
        }
    }


}
