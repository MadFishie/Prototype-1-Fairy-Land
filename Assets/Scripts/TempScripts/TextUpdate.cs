using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextUpdate : MonoBehaviour
{

    [SerializeField]Text Grass,Dark,Candy,Snow;

  
    private void Update()
    {
        Grass.text=TypesCaptured.GrassGrab.ToString();
        Dark.text = TypesCaptured.DarkGrab.ToString();
        Candy.text = TypesCaptured.CandyGrab.ToString();
        Snow.text = TypesCaptured.SnowGrab.ToString();
    }


}
    