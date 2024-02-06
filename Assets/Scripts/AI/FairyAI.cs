using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class FairyAI : MonoBehaviour
{
    

    public Action<ElementTyping.Element> SendType;

    [SerializeField] Animation animator;

    [SerializeField] ElementTyping.Element ElementType;

    [SerializeField][Range(0,100)] float Speed;

    
    

    bool captured=false;


    public float wanderRadius;
    public float wanderTimer;


    private Transform target;
    private NavMeshAgent agent;
    private float timer;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        agent.speed = Speed;
    }

   


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }





    static public FairyAI[] GrabAllFariesInScene() 
    {
        var faries=FindObjectsOfType<FairyAI>();
        return faries;
            
    }

    public void ChangeElement(ElementTyping.Element elementChange) 
    {
        ElementType = elementChange;
    }


    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Net"&&!captured)
        {
            captured = true;
            SendType(ElementType);
            animator.Play("Wound");
            Destroy(gameObject,.2f);
        }
    }



}
