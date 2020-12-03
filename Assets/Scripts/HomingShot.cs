using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingShot : MonoBehaviour
{
    // The target that the shot will travel to.
    private Transform _shotTarget = null;

    // The position of the target.
    private Transform _shotTargetPos = null;

    // Rigidbody of the shot to control velocity.
    private Rigidbody _shotRigidBody;

    // Travel speed of the shot.
    private float _speed = 20.0f;

    // Direction the shot travels in for rotation purposes.
    private Vector3 _dir;

    // Speed that the object will move when rotated.
    private float _rotationSpeed = 360f;

    // Reference to the player gameobject to pull information from.
    GameObject _player;


    /* Boolean that affects the tracking behavior of the homing shots.
     * ENABLED: The shots will change their trajectory mid flight to a new valid target if one is detected.
     * DISABLED: The shots will choose an inital target and will only travel towards that location. 
     *           If the target was destroyed before reaching the shot reaches it the shot will continue flying along its current trajectory.
    */
    private bool _strictTracking;

    // Start is called before the first frame update
    void Start()
    {
        // Find the player object via a tag.
        _player = GameObject.FindGameObjectWithTag("Player");

        _strictTracking = _player.GetComponent<Player>()._strictTracking;

        // Store the rigidbody of the shot object.
        _shotRigidBody = GetComponent<Rigidbody>();

        // If the shot target exists then find it's position.
        if (_shotTarget != null)
        {
            _shotTargetPos = _shotTarget.transform;
        }

        // Pull the best target found by the Player script.
        //_shotTarget = _player.GetComponent<Player>()._bestTarget;
    }

    // Update is called once per frame
    void Update()
    {
        // If strict tracking is enabled, then continuously pull for the best target from the player.
        if (_strictTracking == true)
        {
            //_shotTarget = _player.GetComponent<Player>()._bestTarget;
        }

        // Check if the designated target still exists.
        if (_shotTarget != null)
        {
            // If the target is in the process of destroying itself then ignore it on the for-each search.
            if (_shotTarget.GetComponent<Enemy>().exploded != true)
            {
                // Update position of target
                _shotTargetPos = _shotTarget.transform;

                // Calculate and normalize direction.
                _dir = (_shotTarget.position - transform.position).normalized;

                // Set travel angle.
                float angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;

                // This might need to be looked at if we use a shot sprite that isn't a circle.
                // Rotate object towards target.
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_dir), Time.deltaTime * _rotationSpeed);

                // Adjust angles of object on only the z axis.
                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

                // Set travel velocity of the rigidbody.
                _shotRigidBody.velocity = new Vector3(_dir.x * 20, _dir.y * 20, 0);
            }
        }

        // If there is no viable target that exists, the shot will travel in a straight line to the right.
        if (_shotTarget == null)
        {
            _shotRigidBody.AddForce(transform.right * 0.45f, ForceMode.Impulse);
        }

        // Runs a function that checks if the shot leaves the bounds of the screen and deletes the shot if true.
        BoundCheck();
    }


    void BoundCheck()
    {
        if (transform.position.x > 35.0f || transform.position.x < -35.0f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Debug.Log("Bound Broken");
            Destroy(gameObject);
        }

        if (transform.position.y > 19.0f || transform.position.y < -19.0f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Debug.Log("Bound Broken");
            Destroy(gameObject);
        }
    }
}
