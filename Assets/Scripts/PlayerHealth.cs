using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hearts = 3;
    public int maxHearts = 5;
    public int sodaLife = 0;
    [SerializeField] HeartSystem hs;
    [SerializeField] SodaCounter sc;

    public void Start()
    {
        hs.DrawHeart(hearts, maxHearts);
    }
    // Start is called before the first frame update
    public void TakeDamage(int d)
    {
        hearts -= d;
        hs.DrawHeart(hearts, maxHearts);
    }

    public void HealDamage(int d)
    {
        if (hearts > maxHearts)
        {
            sodaLife += d;
        }
        else
        {
            hearts += d;
        }
        hs.DrawHeart(hearts, maxHearts);
        sc.SetCount(sodaLife);
    }

    public int getSodaLife()
    {
        return sodaLife;
    }

    public void setSodaLife(int newSodaLife)
    {
        sodaLife = newSodaLife;
        sc.SetCount(sodaLife);
    }

    /*public Vector3 GetPosition()
    {
        return transform.position;
    }

    public int[] GetHealth()
    {
        int[] health = { hearts, maxHearts };
        return health;
    }*/
}
