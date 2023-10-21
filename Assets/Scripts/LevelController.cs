using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] private GameObject nextLevelPanel;
    [SerializeField] private GameObject pauseButton;

    [SerializeField] private AudioSource successSound;
    [SerializeField] private AudioSource finishSong;

    [SerializeField] private GameObject BgMusicObject;

    private bool soundPlayed;
    private bool songPlayed;
    public int level = 0;

    Level level1;
    Level level2;
    Level level3;
    Level level4;
    Level level5;
    Level level6;

    public List<ZombieSpawner> spawners;
    // Start is called before the first frame update
    void Start()
    {
        switch (level)
        {
            case 1:
                StartLevel1();
                break;
            case 2:
                StartLevel2();
                break;
            case 3:
                StartLevel3();
                break;
            case 4:
                StartLevel4();
                break;
            case 5:
                StartLevel5();
                break;
            case 6:
                StartLevel6();
                break;
            default:
                StartLevel1();
                break;
        }

        soundPlayed = false;
        songPlayed = false;
    }

    void FixedUpdate()
    {
        if (level == 1)
        {

            if ((level1?.levelFinished ?? false) && !level1.zombies.Any(x => x.IsDestroyed() == false))
            {
                if (!soundPlayed)
                {
                    successSound.Play();
                    soundPlayed = true;
                }
                Time.timeScale = 0;
                nextLevelPanel.SetActive(true);
                pauseButton.SetActive(false);
            }
        }
        else if (level == 2)
        {

            if ((level2?.levelFinished ?? false) && !level2.zombies.Any(x => x.IsDestroyed() == false))
            {
                if (!soundPlayed)
                {
                    successSound.Play();
                    soundPlayed = true;
                }
                Time.timeScale = 0;
                nextLevelPanel.SetActive(true);
                pauseButton.SetActive(false);
            }
        }
        else if (level == 3)
        {

            if ((level3?.levelFinished ?? false) && !level3.zombies.Any(x => x.IsDestroyed() == false))
            {
                if (!soundPlayed)
                {
                    successSound.Play();
                    soundPlayed = true;
                }
                Time.timeScale = 0;
                nextLevelPanel.SetActive(true);
                pauseButton.SetActive(false);
            }
        }
        else if (level == 4)
        {

            if ((level4?.levelFinished ?? false) && !level4.zombies.Any(x => x.IsDestroyed() == false))
            {
                if (!soundPlayed)
                {
                    successSound.Play();
                    soundPlayed = true;
                }
                Time.timeScale = 0;
                nextLevelPanel.SetActive(true);
                pauseButton.SetActive(false);
            }
        }
        else if (level == 5)
        {

            if ((level5?.levelFinished ?? false) && !level5.zombies.Any(x => x.IsDestroyed() == false))
            {
                if (!soundPlayed)
                {
                    successSound.Play();
                    soundPlayed = true;
                }
                Time.timeScale = 0;
                nextLevelPanel.SetActive(true);
                pauseButton.SetActive(false);
            }
        }
        else if (level == 6)
        {

            if ((level6?.levelFinished ?? false) && !level6.zombies.Any(x => x.IsDestroyed() == false))
            {
                if (!songPlayed)
                {
                    BgMusicObject.GetComponent<AudioSource>().Pause();
                    finishSong.Play();
                    songPlayed = true;
                }
                Time.timeScale = 0;
                nextLevelPanel.SetActive(true);
                pauseButton.SetActive(false);
            }
        }
    }

    public void StartLevel1()
    {
        level1 = new Level(
           new List<Wave>
           {
                new Wave(spawners, 15.0f,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 40.0f,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 75.0f,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 100.0f,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE)
           }
       );
        level1.startLevel();
    }

    public void StartLevel2()
    {
        level2 = new Level(
           new List<Wave>
           {
                new Wave(spawners, 15.0f,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 40.0f,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 75.0f,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 100.0f,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE)
           }
       );
        level2.startLevel();

    }

    public void StartLevel3()
    {
        level3 = new Level(
           new List<Wave>
           {
                new Wave(spawners, 5.0f,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 15.0f,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 30.0f,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 60.0f,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE)
           }
       );
        level3.startLevel();

    }

    public void StartLevel4()
    {
        level4 = new Level(
           new List<Wave>
           {
                new Wave(spawners, 15.0f,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 40.0f,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 75.0f,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 100.0f,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE)
           }
       );
        level4.startLevel();

    }

    public void StartLevel5()
    {
        level5 = new Level(
           new List<Wave>
           {
                new Wave(spawners, 15.0f,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 40.0f,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 75.0f,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.CONEHATZOMBIE),
                new Wave(spawners, 100.0f,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE)
           }
       );
        level5.startLevel();

    }

    public void StartLevel6()
    {
        level6 = new Level(
           new List<Wave>
           {
                new Wave(spawners, 15.0f,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 40.0f,
                Enums.Zombies.METALHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 75.0f,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.METALHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 100.0f,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.METALHATZOMBIE,
                Enums.Zombies.METALHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE),
                new Wave(spawners, 130.0f,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.RUNNERZOMBIE,
                Enums.Zombies.METALHATZOMBIE,
                Enums.Zombies.METALHATZOMBIE,
                Enums.Zombies.METALHATZOMBIE,
                Enums.Zombies.METALHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.CONEHATZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE,
                Enums.Zombies.SIMPLEZOMBIE)
           }
       );
        level6.startLevel();


    }
}
