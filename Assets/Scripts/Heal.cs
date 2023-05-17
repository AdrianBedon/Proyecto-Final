using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && (GameObject.Find("Player").GetComponent<PlayerHealth>().getSodaLife() > 0))
        {
            AlternativeHeal();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>() != null)
        {
            other.gameObject.GetComponent<PlayerHealth>().HealDamage(1);
            gameObject.SetActive(false);
            Destroy(gameObject);
            GameObject.Find("ObjectManager").GetComponent<ObjectManager>().SpawnObject();
        }
    }

    private void AlternativeHeal()
    {
        GameObject.Find("Player").GetComponent<PlayerHealth>().HealDamage(1);
        GameObject.Find("Player").GetComponent<PlayerHealth>().setSodaLife(GameObject.Find("Player").GetComponent<PlayerHealth>().getSodaLife() - 1);
    }
}
