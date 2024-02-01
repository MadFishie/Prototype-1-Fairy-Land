using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform PlayerRespawnPoint;
    [SerializeField] private int PlayerLives =>Health;
    public static int Health;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
    

                player.transform.position = PlayerRespawnPoint.transform.position;
                Health = Health - 1;
                Physics.SyncTransforms();
            

        }
    }
}

