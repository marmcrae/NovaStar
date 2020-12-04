using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Follower : MonoBehaviour
{
    [SerializeField]
    private GameObject follower;

    [SerializeField]
    private GameObject followTarget;

    [SerializeField]
    private float xOffset;


    [SerializeField]
    private float yOffset;


    [SerializeField]
    private float zOffset;

    private Transform targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = followTarget.transform;
        follower.transform.position = new Vector3(targetPos.position.x + xOffset, targetPos.position.y + yOffset, targetPos.position.z + zOffset);
    }

    // Update is called once per frame
    void Update()
    {
        follower.transform.position = new Vector3(targetPos.position.x + xOffset, targetPos.position.y + yOffset, targetPos.position.z + zOffset);
    }

}
