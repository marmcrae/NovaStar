using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool exploded = false;
    public bool beamCollision = false;
    public bool beamHit = false;
    public float hitTime;

    [SerializeField]
    public float iFrameTime = 0.3f;

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
        if (other.tag == "Fireball")
        {
            Debug.Log("Fireball Hit detected");
            Debug.Log("Damage Dealt");
        }

        if (other.tag == "Wave")
        {
            Debug.Log("Wave Hit detected");
            Debug.Log("Damage Dealt");
            beamHit = true;
        }

    }

    private void OnTriggerStay(Collider beam)
    {
        if (beam.tag == "Beam")
        {
            beamCollision = true;
            Debug.Log("Beam Hit detected");
        }

        if(beamCollision == true)
        {
            if (beamHit == false)
            {
                Debug.Log("Damage Dealt");
                hitTime = Time.time;
                beamHit = true;

                StartCoroutine(HitTimer());
            }
        }
    }

    private void OnTriggerExit(Collider beam)
    {
        if (beamCollision == true)
        {
            beamCollision = false;
            Debug.Log("Beam Collision Ended");
        }
    }

    IEnumerator HitTimer()
    {
        yield return new WaitForSeconds(iFrameTime);
        beamHit = false;
    }

}
