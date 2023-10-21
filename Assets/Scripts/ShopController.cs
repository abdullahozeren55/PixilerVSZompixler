using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    public TextMeshPro Text;
    [SerializeField] public static int sunAmount;
    // Start is called before the first frame update
    void Start()
    {
        sunAmount = 50;
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = sunAmount.ToString();
    }

    public static void UpdateSunAmount(int sun)
    {
        sunAmount += sun;
    }
}
