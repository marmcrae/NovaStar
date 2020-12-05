using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Follower : MonoBehaviour
{
    [SerializeField]
    public GameObject follower;

    [SerializeField]
    private GameObject followTarget;

    [SerializeField]
    private float xOffset;


    [SerializeField]
    private float yOffset;


    [SerializeField]
    private float zOffset;

    private Transform targetPos;

    public int objState;

    // Start is called before the first frame update
    void Start()
    {
        objState = 0;
        targetPos = followTarget.transform;
        //follower.transform.position = new Vector3(targetPos.position.x + xOffset, targetPos.position.y + yOffset, targetPos.position.z + zOffset);



    }

    // Update is called once per frame
    void Update()
    {

        switch (objState)
        {
            case 0:
                if (follower == null)
                {

                }
                else
                {
                    follower.transform.position = new Vector3(targetPos.position.x + xOffset, targetPos.position.y + yOffset, targetPos.position.z + zOffset);
                }
                break;
            case 1:
                if (follower == null)
                {

                }
                else
                {
                    follower.transform.position = new Vector3(targetPos.position.x + 2.3f, targetPos.position.y + -0.24f, targetPos.position.z);
                }
                break;
            case 2:
                if (follower == null)
                {

                }
                else
                {
                    follower.transform.position = new Vector3(targetPos.position.x + 38.1f, targetPos.position.y, targetPos.position.z);
                }
                break;

        }

        
    }



}
