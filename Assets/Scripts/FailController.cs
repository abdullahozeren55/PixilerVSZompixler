using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailController : MonoBehaviour
{
    [SerializeField] private GameObject failPanel;
    [SerializeField] private GameObject pauseButton;

    [SerializeField] private AudioSource failSound;

    private bool soundPlayed;
    // Start is called before the first frame update
    void Start()
    {
        soundPlayed = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Zombies")
        {
            if (!soundPlayed)
            {
                failSound.Play();
                soundPlayed = true;
            }

            Time.timeScale = 0;

            failPanel.SetActive(true);
            pauseButton.SetActive(false);
        }
    }
}
