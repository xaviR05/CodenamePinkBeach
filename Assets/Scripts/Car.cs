using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [System.Serializable]
    public class Axilinfo
    {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;

        public bool motor;
        public bool steering;
    }

    public List<Axilinfo> Axilinfos = new List<Axilinfo>();
    public float maxMotorTorque;
    public float maxSteeringAngles;

    public void ApplyLocalPositionToVisual(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngles * Input.GetAxis("Horizontal");

        foreach(Axilinfo axilinfo in Axilinfos)
        {
            if (axilinfo.steering == true)
            {
                axilinfo.leftWheel.steerAngle = steering;
                axilinfo.rightWheel.steerAngle = steering;
            }
            if (axilinfo.motor == true)
            {
                axilinfo.leftWheel.motorTorque = motor;
                axilinfo.rightWheel.motorTorque = motor;
            }

            ApplyLocalPositionToVisual(axilinfo.leftWheel);
            ApplyLocalPositionToVisual(axilinfo.rightWheel);
        }
    }
}
