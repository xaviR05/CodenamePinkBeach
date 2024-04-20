using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    [SerializeField] private float bulletSpeed = 40f;

    private Rigidbody bulletRigidbody;
    void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        bulletRigidbody.velocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletTarget>() != null)
        {
            //Hit target
            //Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
            Debug.Log("ENEMY HITTED");
        }
        else
        {
            //Hit something else
            //Instantiate(vfxHitRed, transform.position, Quaternion.identity);
            Debug.Log("Nothing Hitted");
        }
        Destroy(gameObject);
    }
}
