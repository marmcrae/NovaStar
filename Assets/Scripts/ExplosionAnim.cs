using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnim : MonoBehaviour
{
    [SerializeField] private float _animTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _animTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
