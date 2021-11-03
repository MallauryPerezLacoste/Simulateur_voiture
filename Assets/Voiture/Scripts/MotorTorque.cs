using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorTorque : MonoBehaviour
{
    public AnimationCurve motorTorque;
    public AnimationCurve gearRatio;
    public int minRPM;
    public float finalDriveRatio;

    public WheelCollider AvantDroite;
    public WheelCollider AvantGauche;

    public int gearIndex;
    public float accel;//0->1

    float motorRPM;

    void Update()
    {
        applyTorqueToWheels();
        Debug.Log(transform.parent.GetComponent<Rigidbody>().velocity.magnitude);
    }

    float calculatetotalMotorTorque()
    {
        float wheelsRPM = (AvantDroite.rpm + AvantGauche.rpm + AvantGauche.rpm ) / 2;
        motorRPM = minRPM + (wheelsRPM * finalDriveRatio * gearRatio.Evaluate(gearIndex));

        return motorTorque.Evaluate(motorRPM) * gearRatio.Evaluate(gearIndex) * finalDriveRatio * accel;
    }
    
    void applyTorqueToWheels()
    {
        float totalMotorTorque = calculatetotalMotorTorque()/2;
        AvantDroite.motorTorque=totalMotorTorque;
        AvantGauche.motorTorque=totalMotorTorque;
        return;
    }
}
