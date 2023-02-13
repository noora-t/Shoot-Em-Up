using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] ProjectilePool _projectilePool;
    [SerializeField] GameObject _turret;
    [SerializeField] GameManager _gameManager;
    [SerializeField] float _speed = 20f;
    [SerializeField] float _turnSpeed = 300f;

    float _horizontalMovement;
    float _verticalMovement;

    void Update()
    {
        // Movement

        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
        Vector2 movement = Vector2.up * _verticalMovement;
        Vector3 rotation = Vector3.forward * -_horizontalMovement;
        transform.Rotate(rotation * _turnSpeed * Time.deltaTime);
        transform.Translate(movement * _speed * Time.deltaTime);

        // Shooting
        if (Input.GetKeyDown(KeyCode.Space) && !_gameManager.GameIsPaused)
        {
            GameObject projectile = _projectilePool.GetProjectile();
            if (projectile != null)
            {
                projectile.transform.position = _turret.transform.position;
                projectile.transform.rotation = transform.rotation;
                projectile.SetActive(true);
            }          
        }

        // Boundaries

        if (transform.position.x < -8.2f)
            transform.position = new Vector3(-8.2f, transform.position.y, 0);
        else if (transform.position.x > 8.2f)
            transform.position = new Vector3(8.2f, transform.position.y, 0);

        if (transform.position.y < -4.25f)
            transform.position = new Vector3(transform.position.x, -4.25f, 0);
        else if (transform.position.y > 4.25f)
            transform.position = new Vector3(transform.position.x, 4.25f, 0);
    }
}
