using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testOrientation : MonoBehaviour
{
    public float orientation;

    // Update is called once per frame
    void Update()
    {
        orientation = gameObject.GetComponent<ReadDataPort>().Values[0]/10;
        gameObject.transform.Rotate(0, orientation * Time.deltaTime, 0, Space.Self);
    }
}
