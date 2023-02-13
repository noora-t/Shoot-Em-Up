using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] float _speed = 5;


    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * _speed);

        // Boundaries
        if (transform.position.y > 6 || transform.position.y < -6 || transform.position.x > 10 || transform.position.x < -10)
        {
            gameObject.SetActive(false);
        }
    }
}
