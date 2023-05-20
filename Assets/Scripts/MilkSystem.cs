using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>() != null)
        {
            other.gameObject.GetComponent<PlayerHealth>().setMilk(other.gameObject.GetComponent<PlayerHealth>().getMilk() + 1);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
