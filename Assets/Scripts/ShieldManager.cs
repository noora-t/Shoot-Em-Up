using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    [SerializeField] GameObject _shieldItemPrefab;

    public void SpawnShieldItem()
    {
        Instantiate(_shieldItemPrefab, new Vector2(6, -3), transform.rotation);
    }
}
