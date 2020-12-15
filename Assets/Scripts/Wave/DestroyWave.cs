using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWave : MonoBehaviour
{
    [SerializeField]
    Transform waveObject;
    // Start is called before the first frame update
    void Start()
    {
        waveObject = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(waveObject.childCount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
