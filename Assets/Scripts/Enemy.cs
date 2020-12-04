using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool exploded = false;

    public bool beamHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fireball")
        {
            Debug.Log("Hit detected");
        }

        if (other.tag == "Wave")
        {
            Debug.Log("Hit detected");

            beamHit = true;
        }

    }

    private void OnTriggerStay(Collider beam)
    {
        if (beam.tag == "Beam")
        {
            Debug.Log("Hit detected");

            beamHit = true;
        }
    }
}
