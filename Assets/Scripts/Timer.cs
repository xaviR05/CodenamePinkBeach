using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float hour;
    public float minut;
    private string hour0, minut0;
    public GameObject textoTimer;

    void Update()
    {
        minut += Time.deltaTime;
        //textoTimer.text = "" + timer.ToString("f0");
        if (minut > 59f)
        {
            if (hour >= 23 || hour < 0)
            {
                hour = 0;
            }
            else
            {
                hour += 1;
            }
            minut = 0;
        }

        if (hour < 10)
        {
            hour0 = "0";
        }
        else
        {
            hour0 = "";
        }

        if (minut < 9.5f)
        {
            minut0 = "0";
        }
        else
        {
            minut0 = "";
        }

        textoTimer.gameObject.GetComponent<TMP_Text>().text = hour0 + hour.ToString("f0") + ":" + minut0 + minut.ToString("f0");
    }
}
