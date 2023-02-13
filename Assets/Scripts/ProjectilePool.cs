using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] int _poolSize = 20;
    [SerializeField] GameObject _projectile;

    List<GameObject> _pool;

    void Start()
    {
        _pool = new List<GameObject>();
        GameObject temp;
        for (int i = 0; i < _poolSize; i++)
        {
            temp = Instantiate(_projectile);
            temp.SetActive(false);
            _pool.Add(temp);
        }
    }

    public GameObject GetProjectile()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            if (!_pool[i].activeInHierarchy)
                return _pool[i];
        }
        return null;
    }
}
