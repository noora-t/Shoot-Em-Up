using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _explosionParticle;
    [SerializeField] float _speed = 0.1f;

    GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector2 moveDirection = _player.transform.position - transform.position;
        transform.Translate(moveDirection * _speed * Time.deltaTime);

        // Boundaries
        if (transform.position.y > 6 || transform.position.y < -6 || transform.position.x > 10 || transform.position.x < -10)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            collision.gameObject.SetActive(false);
            Instantiate(_explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
