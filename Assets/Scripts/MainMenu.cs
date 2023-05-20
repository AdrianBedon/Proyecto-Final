using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public class Data
    {
        public Vector3 mPosition;
        public int mScene;
    }
    public TextAsset jsonText; 
    public Data dt = new Data();
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        dt =  JsonUtility.FromJson<Data>(File.ReadAllText(Application.dataPath + "/data.json"));
        SceneManager.LoadScene(dt.mScene);
        PlayerHealth.Position = dt.mPosition;
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
