using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBBomb : MonoBehaviour
{
    private float _speed = 15.0f;

    // Update is called once per frame
    void Update()
    {
        //add acceleration
        transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.World);
        transform.Rotate(1, 1, 1 * Time.deltaTime);

        if (transform.position.y <= -25.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
