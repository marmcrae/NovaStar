using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBomb : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -55.0f)
        {
            //destroys the parent and the grandparent
            Destroy(transform.root.gameObject);
        }
    }
}
