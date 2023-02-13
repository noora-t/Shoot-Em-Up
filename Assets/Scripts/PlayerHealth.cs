using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject _explosionParticle;
    [SerializeField] TMP_Text _healthText;
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject _shield;

    int _health = 3;
    bool _shieldIsActive = false;
    int _shieldDuration = 8;

    void Start()
    {
        Time.timeScale = 1;
        _healthText.text = _health.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_shieldIsActive)
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyProjectile"))
            {
                Destroy(collision.gameObject);
                Instantiate(_explosionParticle, transform.position, transform.rotation);
                TakeDamage();
            } 
            else if (collision.gameObject.CompareTag("ShieldItem"))
            {
                Destroy(collision.gameObject);
                StartCoroutine("ActivateShield");
            }
        } 
    }

    void TakeDamage()
    {
        _health--;
        _healthText.text = _health.ToString();

        if (_health == 0)
            _gameManager.DisplayGameOver();
    }

    public IEnumerator ActivateShield()
    {
        _shield.SetActive(true);
        _shieldIsActive = true;
        yield return new WaitForSeconds(_shieldDuration);
        _shield.SetActive(false);
        _shieldIsActive = false;
    }
}
