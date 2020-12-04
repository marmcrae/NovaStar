using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormLaserParent : MonoBehaviour
{
    [SerializeField] private Transform _parentHolder;

    private void Start()
    {
        this.transform.parent = _parentHolder.transform;
    }
    private void Update()
    {
        
    }
}
