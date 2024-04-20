using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class LookAtObjectAnimationRigging : MonoBehaviour
{

    private Rig rig;
    private float targetWeight;
    void Awake()
    {
        rig = GetComponent<Rig>();
    }

    void Update()
    {
        rig.weight = Mathf.Lerp(rig.weight, targetWeight, Time.deltaTime * 10f);
        if (Input.GetKeyDown(KeyCode.T))
        {
            targetWeight = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            targetWeight = 0f;
        }
    }
}
