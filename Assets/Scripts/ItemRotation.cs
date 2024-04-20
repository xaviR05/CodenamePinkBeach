using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    float y;
    void Update()
    {
        y += Time.deltaTime * 80;
        transform.rotation = Quaternion.Euler(0, y, 0);
    }
}
