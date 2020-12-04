using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormLaser : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -45.0f)
        {
            Destroy(transform.parent.gameObject);        
        }
    }
}
