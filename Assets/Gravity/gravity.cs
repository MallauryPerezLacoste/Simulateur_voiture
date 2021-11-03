using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    public float G;
    public float MParticule;
    public float MCentre;

    public Transform Autre;

    public float MaxDistance;
    

    Rigidbody mine;
    private void Start()
    {
        mine = GetComponent<Rigidbody>();
        mine.mass = MParticule;
    }

    void Update()
    {
        mine.AddForce(valeurForce() * direction());
        if (distance() > MaxDistance) Destroy(gameObject);
    }


    float distance()
    {
         return Vector3.Distance(Autre.position, transform.position);
    }

    Vector3 direction()
    {
        return Autre.position - transform.position;
    }

    float valeurForce()
    {
        return G * MParticule * MCentre / (distance() * distance());
    }
}
