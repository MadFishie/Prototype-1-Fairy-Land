using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TypesCaptured : MonoBehaviour
{

    static public int GrassGrab, SnowGrab, CandyGrab, DarkGrab;
    [SerializeField][Range(0,100)]static int MaxCapNum = 5;
    public static TypesCaptured current;

    [SerializeField] GameObject[] Walls;




    private void Awake()
    {
        current = this;
        AddFaries();
    }

   

    private void OnDisable()
    {
        SubFaries();
    }

    public static void AddFaries()
    {
        try 
        {
            foreach (var item in FairyAI.GrabAllFariesInScene())
            {

                item.SendType += current.GrabElement;

            }

        }
        catch { }
       
    }


    public static void SubFaries()
    {
        try 
        {
            foreach (var item in FairyAI.GrabAllFariesInScene())
            {
                item.SendType -= current.GrabElement;

            }


        }
        catch { }
      
    }

    public static bool isRegionUnlocked(ElementTyping.Element element) 
    {
        switch (element)
        {
            case ElementTyping.Element.Candy:
                return CandyGrab >= MaxCapNum;
               
            case ElementTyping.Element.Dark:
                return DarkGrab >= MaxCapNum;
            case ElementTyping.Element.Ice:
                return SnowGrab >= MaxCapNum;
            default:
                return GrassGrab >= MaxCapNum;


        }
    }


    public void GrabElement(ElementTyping.Element ElementCapture) 
   {
        switch (ElementCapture) 
        {
            case ElementTyping.Element.Candy:
                CandyGrab += 1;
                Debug.Log("Captured" + ElementCapture.ToString() + CandyGrab);
                break;
            case ElementTyping.Element.Dark:
                DarkGrab += 1;
                Debug.Log("Captured" + ElementCapture.ToString() + DarkGrab);
                break;
            case ElementTyping.Element.Ice:
                SnowGrab += 1;
                Debug.Log("Captured" + ElementCapture.ToString() + SnowGrab);
                break;
            default:
                GrassGrab += 1;
                Debug.Log("Captured" + ElementCapture.ToString() + GrassGrab);
                break;
            

        }
        if (isRegionUnlocked(ElementCapture)) 
        {
            if (((int)ElementCapture) == 1) { SceneLoader.loadScenebyName("VictoryScreen"); }
            Walls[((int)ElementCapture)].SetActive(false);

        }



   }


    

}
