using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public float money;
    //private string[] additonal0s = new string [8] {"0", "0", "0", "0", "0", "0", "0", "0"};
    public GameObject moneyText;

    void Update()
    {
        moneyText.gameObject.GetComponent<TMP_Text>().text = "$" + money.ToString("f0");
    }

    public void AddMoney(float moneyAdded)
    {
        if (money < 99999999f)
        {
            money += moneyAdded;
        }
        else
        {
            money = 99999999f;
        }
    }

    public void SubstractMoney(float moneyAdded)
    {
        if (money > 0f)
        {
            money -= moneyAdded;
        }
        else
        {
            money = 0f;
        }
    }
}
