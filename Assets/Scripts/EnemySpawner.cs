using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _bossPrefab;

    int _maxWaves = 5;
    int _currentWave = 1;
    int _enemyCount;
    bool _waveActivated = false;

    void Update()
    {
        _enemyCount = FindObjectsOfType<Enemy>().Length;

        if (!_waveActivated && _enemyCount == 0)
        {
            _waveActivated = true;

            if (_currentWave < _maxWaves)
            {
                StartCoroutine("SpawnEnemyWave");
                _currentWave++;
            }
            else
            {
                SpawnBoss();
            }
        }
    }

    /*
     * Randomizes positions for enemies to spawn either on top, left, bottom or right of the area.
     */
    IEnumerator SpawnEnemyWave()
    {
        yield return new WaitForSeconds(1);

        int enemyCount = _currentWave * 3;
        for (int i = 0; i < enemyCount; i++)
        {
            List<Vector2> positions = new List<Vector2>();
            positions.Add(new Vector2(Random.Range(-8, 8), 6));
            positions.Add(new Vector2(Random.Range(-8, 8), -6));
            positions.Add(new Vector2(10, Random.Range(-4, 4)));
            positions.Add(new Vector2(-10, Random.Range(-4, 4)));

            GameObject enemy = Instantiate(_enemyPrefab);

            enemy.transform.position = positions[Random.Range(0, 3)];

            // The more waves there has been, the shorter the time between enemies spawning in each wave
            yield return new WaitForSeconds(1 - (_currentWave/10));
        }

        _waveActivated = false; 
    }

    void SpawnBoss()
    {
        GameObject boss = Instantiate(_bossPrefab);
        boss.transform.position = new Vector2(10, 6);
    }
}

