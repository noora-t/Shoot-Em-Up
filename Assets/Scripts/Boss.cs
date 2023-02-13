using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject _explosionParticle;
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] GameObject _turret;
    [SerializeField] float _rotationSpeed = 150;
    [SerializeField] int _health = 10;

    GameManager _gameManager;
    ShieldManager _shieldManager;

    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _shieldManager = GameObject.Find("Player").GetComponent<ShieldManager>();
        _shieldManager.Invoke("SpawnShieldItem", 8);
        InvokeRepeating("FireProjectile", 2, 0.3f);
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * _rotationSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            collision.gameObject.SetActive(false);
            Instantiate(_explosionParticle, transform.position, transform.rotation);
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        _health--;

        if (_health == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            _gameManager.Invoke("DisplayWin", 2);
        }
    }

    void FireProjectile()
    {
        GameObject projectile = Instantiate(_projectilePrefab);
        projectile.transform.position = _turret.transform.position;
        projectile.transform.rotation = _turret.transform.rotation;
    }
}
