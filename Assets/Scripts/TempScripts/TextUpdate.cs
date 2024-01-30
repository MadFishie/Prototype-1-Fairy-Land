using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextUpdate : MonoBehaviour
{

    Text UpdateText;

    private void Start()
    {
        UpdateText = GetComponent<Text>();
    }

    private void Update()
    {
        UpdateText.text=TypesCaptured.GrassGrab.ToString();
    }


}
