using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class FairyAI : MonoBehaviour
{

    public Action<ElementTyping.Element> SendType;

    [SerializeField] ElementTyping.Element ElementType;

    [SerializeField][Range(0,100)] float Speed;

    [SerializeField][Range (0,100)] float Tolerance;


    static public FairyAI[] GrabAllFariesInScene() 
    {
        var faries=FindObjectsOfType<FairyAI>();
        return faries;
            
    }




    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Net")
        {
            SendType(ElementType);
            Destroy(gameObject);
        }
    }



}
