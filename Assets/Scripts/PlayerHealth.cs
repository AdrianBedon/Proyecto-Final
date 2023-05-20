using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerHealth : MonoBehaviour
{
    public static int hearts = 3;
    public static int maxHearts = 5;
    public static int sodaLife = 0;
    public static Vector3 Position = new Vector3 (0, 0, 0);

    public static int milk = 0;
    [SerializeField] HeartSystem hs;
    [SerializeField] SodaCounter sc;
    [SerializeField] MilkCounter mc;
 
    public void Start()
    {
        hs.DrawHeart(hearts, maxHearts);
        sc.SetCount(sodaLife);
        SetPosition(Position);
        Position = new Vector3(0, 0, 0);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            writeOutString(GetPosition(), GetScene());
        }
        if (hearts == 0)
        {
            death();
            hearts = 3;
            maxHearts = 5;
            sodaLife = 0;
        }
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

    public int getMilk()
    {
        return milk;
    }
    public void setMilk(int newMilk)
    {
        milk = newMilk;
        mc.SetCount(milk);
    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }

    public void SetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public int GetScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public class Data
    {
        public Vector3 mPosition;
        public int mScene;

        public Data(Vector3 position, int scene)
        {
            mPosition = position;
            mScene = scene;
        }
    }

    public void death()
    {
        Application.LoadLevel("MenuPrincipal");
    }
    public void writeOutString(Vector3 position, int scene)
    {
        Data data = new Data(position, scene);
        string strOut = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/data.json", strOut);
        Debug.Log("Guardado");
    }
}
