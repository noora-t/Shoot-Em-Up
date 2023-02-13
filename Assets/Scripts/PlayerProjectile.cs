using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] float _speed = 7;

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * _speed);

        // Boundaries
        if (transform.position.y > 6 || transform.position.y < -6 || transform.position.x > 10 || transform.position.x < -10)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }
}
