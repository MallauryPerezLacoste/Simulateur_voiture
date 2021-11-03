using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frictions : MonoBehaviour
{
    public float Cx;
    public float S;

    Rigidbody mine;

    private void Start()
    {
        mine = transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mine.AddForce(direction()*aeroFrottement()*((float)-1.0));
        Debug.Log("Frottement" + aeroFrottement());
    }



    Vector3 direction()
    {
        return (transform.parent.transform.forward) ;
    }

    float aeroFrottement()
    {
        return (float)(0.5 * S * getVitesse() * getVitesse() * Cx);
    }
    float getVitesse()
    {
        return mine.velocity.magnitude;
    }
}
