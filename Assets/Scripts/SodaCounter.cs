using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SodaCounter : MonoBehaviour
{
    [SerializeField] public Text txt;

    public void SetCount(int count)
    {
        txt.text = count.ToString();
    }
}
