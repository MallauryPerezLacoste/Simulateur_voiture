using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generationParticule : MonoBehaviour
{
    public int nbParticules;
    public GameObject Particule;

    public float maxVitesse;
    public float maxDistance;



    public float G;
    public float MParticule;
    public float MCentre;

    public Transform Autre;

    public float MaxDistance;


    void Start()
    {
        

        for (int i = 0; i < nbParticules; i++)
        {
            GameObject newParticule=Instantiate(Particule, new Vector3(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance)), new Quaternion());
            //Color
            newParticule.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            //vitesse initiale
            newParticule.GetComponent<Rigidbody>().velocity = transform.forward * Random.Range(-maxVitesse, maxVitesse)+
                                                              transform.up * Random.Range(-maxVitesse, maxVitesse)+
                                                              transform.right * Random.Range(-maxVitesse, maxVitesse);

            gravity gravity = newParticule.GetComponent<gravity>();
            gravity.G = G;
            gravity.MParticule = MParticule;
            gravity.MCentre = MCentre;
            gravity.Autre = Autre;
            gravity.MaxDistance = MaxDistance;
        }
    }

}
