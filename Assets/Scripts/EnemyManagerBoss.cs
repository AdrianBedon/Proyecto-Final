using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManagerBoss : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;
    int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        int count = 1;
    }

    // Update is called once per frame
    void OnEnable()
    {
        EnemySystemBoss.OnEnemyKilled += SpawnEnemy;
    }

    void OnDisable()
    {
        EnemySystemBoss.OnEnemyKilled -= SpawnEnemy;
    }

    void SpawnEnemy()
    {
        if (count <= 2)
        {
            Instantiate(m_EnemyPrefab, m_SpawnPoints[Random.Range(0, m_SpawnPoints.Length)].transform.position, Quaternion.identity);
            count += 1;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
