using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    #region Script Communication
    private GameObject _playerRotation;
    private Transform _player;
    #endregion

    #region Player Movement Parameters
    [SerializeField]
    private float _speed;  //set in inspector, 20 worked well.
    private Quaternion _resetRot;
    private float _accelerate;
    #endregion

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _playerRotation = transform.Find("Player_Rotation").gameObject;
        _resetRot = Quaternion.Euler(0, 90, 0);
        transform.position = _player.transform.position;
    }

    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            _playerRotation.transform.rotation = Quaternion.Euler(0, 90, 55);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            _playerRotation.transform.rotation = _resetRot;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _playerRotation.transform.rotation = Quaternion.Euler(0, 90, -55);

        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            _playerRotation.transform.rotation = _resetRot;
        }

        //checks for horizontal input to change any animations we may need based on a float value
        _accelerate = horizontalInput;
    }

    public float Accelerate()
    {
        return _accelerate;
    }

}
