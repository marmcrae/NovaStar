using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [SerializeField]
    private GameObject laserSprite;

    [SerializeField]
    private Animator laserAnim;

    private bool _weaponActive = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_weaponActive)
        {
            
        } 
    }
}
