using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigBuilderEnabler : MonoBehaviour
{
    public RigBuilder rb;

    void Start()
    {
        rb = GetComponent<RigBuilder>();

        // disables the rigbuilder script
        rb.enabled = false;
    }
}
