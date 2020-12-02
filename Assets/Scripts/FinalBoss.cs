using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    
    //1st attack pattern
    //Boss turn red and fires charged beam
    //2nd attack pattern enables at 50% hp
    //Boss goes to top of the screen, slows down and activates a downward beam while moving backwards
    //hp
    [SerializeField] private int _hp = 100;

    //movement
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private Transform _curTarget;
    private int _startDirection;
    private int _randDirection;
    private bool _newDirection;
    //basic movement
    //basic fire

    // Start is called before the first frame update
    void Start()
    {
        _startDirection = Random.Range(0, 2);
        //Sets Random Direction at Start
        if (_startDirection == 0)
        {
            _curTarget = _pointA;
        }
        else if (_startDirection == 1)
        {
            _curTarget = _pointB;
        }
    }

    // Update is called once per frame
    void Update()
    {       
        StandardMovement();      
    }
    private void BossEntrance()
    {
        //entrance pattern
        //boss moves onto screen and rotates to face the player
    }
    private void StandardMovement()
    {
        //Boss moves up and down on y axis randomly
        transform.position = Vector3.MoveTowards(transform.position, _curTarget.position, _speed * Time.deltaTime);

        if (_curTarget == _pointA && transform.position != _pointA.position)
        {
            _curTarget = _pointA;
        }
        else
        {
            _curTarget = _pointB;
        }
        if (_curTarget == _pointB && transform.position != _pointB.position)
        {
            _curTarget = _pointB;
        }
        else
        {
            _curTarget = _pointA;
        }
        if (_newDirection == false)
        {
            _newDirection = true;
            StartCoroutine(RandomDirection());
        }
    }
    IEnumerator RandomDirection()
    {   
        //Controls enemy direction towards point a or point b
        yield return new WaitForSeconds(Random.Range(1.5f, 4.0f));
        _randDirection = Random.Range(0, 2);
        Debug.Log("Coroutine " + _randDirection);
        if (_randDirection == 0)
        {
            _curTarget = _pointA;
        }
        if (_randDirection == 1)
        {
            _curTarget = _pointB;
        }
        _newDirection = false;
    }
    private void SecondPhaseAbility()
    {
        //can just move to point b 
        //need to disable standard movement until after this ability finishes
        _pointB.position = new Vector3(transform.position.x, 15.0f, 0);
        if (Vector3.Distance(transform.position, _pointB.position) > 1.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _speed * Time.deltaTime);
        }
        
    }
}
