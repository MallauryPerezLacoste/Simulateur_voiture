using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTurn : MonoBehaviour
{

    public WheelCollider AvantDroite;
    public WheelCollider AvantGauche;

    public float anglemaxRoue;

    public float angle;
    public float angleMax;
    

    void Update()
    {
        braquageRoue();
    }

    float angleRoue()
    {
        return (angle / angleMax) * anglemaxRoue;
    }

    void braquageRoue()
    {
        AvantDroite.steerAngle=angleRoue();
        AvantGauche.steerAngle=angleRoue();
    }
}
