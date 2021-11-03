using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDeplacement : MonoBehaviour
{
    public float acceleration;
    public float deceleration;
    public int MaxVelocity;
    public int minVelocity;

    private Rigidbody Mine;
    // Start is called before the first frame update
    void Start()
    {
        Mine = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        adVelocity();
        supprVelocity();
        Debug.Log("Vitesse" + Mine.velocity.magnitude);
    }

    void adVelocity()
    {
        acceleration = gameObject.GetComponent<ReadDataPort>().Values[1];

        if (Mine.velocity.magnitude >= MaxVelocity)
        {
            Mine.velocity = Mine.velocity.normalized * MaxVelocity;
        }
        else
        {
            Mine.AddForce(transform.forward * acceleration * MaxVelocity * Time.deltaTime);
        }
    }

    void supprVelocity()
    {
        deceleration = gameObject.GetComponent<ReadDataPort>().Values[2];

        if (Mine.velocity.magnitude < minVelocity)
        {
            Mine.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            float tem = deceleration * Mine.velocity.magnitude * Time.deltaTime+1;
            Mine.AddForce(-Mine.velocity * tem);
        }

    }
}
