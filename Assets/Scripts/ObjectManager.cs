using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ObjectManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_ObjectPrefab;
    int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        GameObject nb = Instantiate(m_ObjectPrefab, m_SpawnPoints[Random.Range(0,m_SpawnPoints.Length)].transform.position, Quaternion.identity) as GameObject;
        count += 1;
    }
}
