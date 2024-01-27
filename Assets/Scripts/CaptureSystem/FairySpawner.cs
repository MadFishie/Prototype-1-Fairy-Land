using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairySpawner : MonoBehaviour
{
    [SerializeField]ElementTyping.Element elementSpawn;
    [SerializeField][Range(1,100)]int AmountSpawn;
    [SerializeField] GameObject FairyPrefab;
    


    private void Awake()
    {
        if(FairyPrefab == null) { Debug.LogWarning("You forgot to set prefab on spawner hobo "+this); return; }
        TypesCaptured.SubFaries();
        for (int i = 0; i <= AmountSpawn; i++) 
        {
            var Spawnpoint = transform.GetChild(Random.Range(0, transform.childCount));


            GameObject fairy=Instantiate(FairyPrefab,Spawnpoint,Spawnpoint)as GameObject;

            fairy.GetComponent<FairyAI>().ChangeElement(elementSpawn);
        }
        TypesCaptured.AddFaries();
    }


}
