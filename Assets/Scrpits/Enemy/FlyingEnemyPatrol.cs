using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

    private Transform _target;
    private int _currentPoint;
    private bool _facingRight;

    private void Update()
    {
        _target = _waypoints[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position.x < _target.position.x && _facingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            _facingRight = false;
        }
        else if (transform.position.x > _target.position.x && !_facingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            _facingRight = true;
        }

        if (transform.position == _target.position)
        {
            _currentPoint++;
            if (_currentPoint >= _waypoints.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}