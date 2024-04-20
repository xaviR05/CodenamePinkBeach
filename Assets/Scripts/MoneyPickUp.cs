using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickUp : MonoBehaviour
{
    private GameObject MoneyController;

    void Start()
    {
        MoneyController = GameObject.Find("MoneyController");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            int rnd = Random.Range(1, 101);
            MoneyController.GetComponent<Money>().AddMoney(rnd);
            Destroy(gameObject);
        }
    }
}
