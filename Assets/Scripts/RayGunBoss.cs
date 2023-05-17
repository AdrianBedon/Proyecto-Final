using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGunBoss : MonoBehaviour
{
    public float shootRate;
    private float m_shootRateTimeStamp;
    private int hitCount;

    public GameObject m_shotPrefab;

    RaycastHit hit;
    float range = 1000.0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(Time.time > m_shootRateTimeStamp)
            {
                ShootRay();
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }
    }

    void ShootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, range))
        {
            EnemySystemBoss enemy = hit.transform.GetComponent<EnemySystemBoss>();
            hitCount++;
            Debug.Log(hitCount.ToString());
            if (enemy != null  && hitCount >= 15)
            {
                hitCount = 0;
                enemy.die();
            }
            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            GameObject.Destroy(laser, 2f);
        }
    }
}
