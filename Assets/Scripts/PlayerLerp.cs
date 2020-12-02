using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLerp : MonoBehaviour
{
    #region Script Communicaitons
    private PlayerPosition _playerPos;
    private Animator _anim;
    #endregion

    #region Targeting
    [SerializeField]
    private float _posSpeed, _rotSpeed;  //set in inspector or hardcode in 10, 5 seem to work well respectively
    [SerializeField]
    private GameObject _posTarget, _rotTarget;
    #endregion

    private float _accelleration;
    private void Start()
    {
        _playerPos = GameObject.Find("Player_Position").GetComponent<PlayerPosition>();
        if (_playerPos == null)
        {
            Debug.LogError("The PlayerPos is NULL.");
        }
        _anim = GetComponentInChildren<Animator>();
        if (_anim == null)
        {
            Debug.LogError("The Animator is NULL.");
        }
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _posTarget.transform.position, _posSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rotTarget.transform.rotation, _rotSpeed * Time.deltaTime);

        CheckAcceleration();     
    }

    private void CheckAcceleration()
    {
        //Debug.Log("Accelleration is: " + _accelleration);
        //Sets float from horizontalInput on Player Position script to set thresholds for animation changes
        _accelleration = _playerPos.Accelerate();
        _anim.SetFloat("Accelleration", _accelleration);
    }
}
