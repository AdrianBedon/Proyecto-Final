using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
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
        EnemySystem.OnEnemyKilled += SpawnEnemy;
    }

    void OnDisable()
    {
        EnemySystem.OnEnemyKilled -= SpawnEnemy;
    }

    void SpawnEnemy()
    {
        if (count <= 20)
        {
            Instantiate(m_EnemyPrefab, m_SpawnPoints[Random.Range(0, m_SpawnPoints.Length)].transform.position, Quaternion.identity);
            count += 1;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
