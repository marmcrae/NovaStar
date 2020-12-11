using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = new Vector3(0f, 0f, 0f);
    }

    
}
