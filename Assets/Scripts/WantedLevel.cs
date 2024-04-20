using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WantedLevel : MonoBehaviour
{
    public RawImage[] Stars;
    [SerializeField]
    private Color WantedOffColor = Color.white;
    [SerializeField]
    private Color WantedOnColor = Color.white;
    int currentLevelCounter = 0;

    void Start()
    {
        foreach (RawImage stars in Stars)
        {
            stars.color = WantedOffColor;
        }
        //Stars[0].color = WantedOffColor;
    }

    void Update()
    {
        if (currentLevelCounter > 5)
        {
            currentLevelCounter = 5;
        }else if (currentLevelCounter < 0)
        {
            currentLevelCounter = 0;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Wanted Level+: " + currentLevelCounter);
            if (currentLevelCounter <= 5)
            {
                //Stars[currentLevelCounter].color = WantedOnColor;
                AddStar(currentLevelCounter);
                currentLevelCounter++;
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Wanted Level-: " + currentLevelCounter);
            if (currentLevelCounter >= 0)
            {
                //Stars[currentLevelCounter].color = WantedOnColor;
                SubstractStar(currentLevelCounter);
                currentLevelCounter--;
            }
        }
        
    }

    public void AddStar(int lvl)
    {
        Stars[lvl].color = WantedOnColor;
    }

    public void SubstractStar(int lvl)
    {
        Stars[lvl].color = WantedOffColor;
    }
}
