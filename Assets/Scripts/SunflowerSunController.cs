using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSunController : MonoBehaviour
{
    [SerializeField] private int sunAmountToCollect;
    [SerializeField] private AudioSource collectSound;

    private bool musicPlayed;
    void Start()
    {
        musicPlayed = false;
        Destroy(gameObject, 10.0f);
    }

    private void OnMouseOver()
    {
        if (!musicPlayed)
        {
            collectSound.Play();
            ShopController.UpdateSunAmount(sunAmountToCollect);
            musicPlayed = true;
        }


        Destroy(gameObject, 0.2f);

    }
}
