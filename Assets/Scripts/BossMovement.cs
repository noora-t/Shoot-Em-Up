using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] Vector2[] _waypoints;

    int _currentWaypoint = 0;
    Vector2 _direction;
    float _accuracy = 2f;

    void Start()
    {
        _direction = _waypoints[_currentWaypoint] - (Vector2)transform.position;
    }

    void Update()
    {
        if (Vector2.Distance(_waypoints[_currentWaypoint], transform.position) < _accuracy)
        {
            _currentWaypoint++;

            if (_currentWaypoint >= _waypoints.Length)
                _currentWaypoint = 0;
        }

        _direction = _waypoints[_currentWaypoint] - (Vector2)transform.position;
        transform.Translate(_direction * Time.deltaTime * _speed);
    }
}
