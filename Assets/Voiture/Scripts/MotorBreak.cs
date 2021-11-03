using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorBreak : MonoBehaviour
{
    public WheelCollider AvantDroite;
    public WheelCollider AvantGauche;
    public WheelCollider ArriereDroite;
    public WheelCollider ArriereGauche;

    public float forceFreinageMax;
    public float deccel;


    void Update()
    {
        motorBreak();
    }
    
    float forceFreinage() { return deccel * forceFreinageMax; }
    void motorBreak()
    {
        float freinage = forceFreinage();
        AvantDroite.brakeTorque=freinage;
        AvantGauche.brakeTorque=freinage;
        ArriereDroite.brakeTorque=freinage;
        ArriereGauche.brakeTorque=freinage;
        return;
    }
}
