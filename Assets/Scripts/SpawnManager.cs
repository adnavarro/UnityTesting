using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _powerupPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemyRoutine()
    {
        while(!_stopSpawning)
        {
            Vector3 position = new Vector3(Random.Range(-8f, 8f), 7.4f, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, position, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5);
        }
    }
    IEnumerator SpawnPowerupRoutine()
    {
        while(!_stopSpawning)
        {
            Vector3 position = new Vector3(Random.Range(-8f, 8f), 8f, 0);
            GameObject powerup = Instantiate(_powerupPrefab, position, Quaternion.identity);
            float spawnTime = Random.Range(5f, 10f);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
