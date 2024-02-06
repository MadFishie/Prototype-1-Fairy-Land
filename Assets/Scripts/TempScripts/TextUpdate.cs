using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextUpdate : MonoBehaviour
{

    [SerializeField]Text Grass,Snow;

  
    private void Update()
    {
        Grass.text=TypesCaptured.GrassGrab.ToString();
        Snow.text = TypesCaptured.SnowGrab.ToString();
    }


}
    