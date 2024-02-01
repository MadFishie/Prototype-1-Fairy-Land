using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HunterNav : MonoBehaviour
{
    [SerializeField] private GameObject NavPoints;
    private List<Transform> NavPointList=new List<Transform>();
    private int NavPointCount;
    public static bool Hunting = false;
    [SerializeField] private Transform player;
    private NavMeshAgent agent;
    private Transform NavPoint;
    private NavMeshPath checkPath;
    private Transform LastPoint;



    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        NavPointCount = NavPoints.transform.childCount;
        NavTarget.TargetReached = false;
        

        foreach (Transform child in NavPoints.transform)
        {
            Debug.Log(child);
            NavPointList.Add(child);
            Debug.Log("point added");
        }   
        
    }

    // Update is called once per frame
    void Update()
    {
        checkPath = new NavMeshPath();
        if (NavTarget.TargetReached==true&&Hunting==false)
        {

            NavPoint = NavPointList[Random.Range(0, NavPointCount)];
            if (NavPoint != LastPoint)
            {

                if (agent.CalculatePath(NavPoint.position, checkPath))
                {
                    agent.destination = NavPoint.position;
                    NavTarget.TargetReached = false;
                    Debug.Log("New target found");
                    LastPoint = NavPoint;
                }
                else { Debug.Log("Target unreachable"); }

            }           
            else { Debug.Log("Repeat target"); }


        }
        if (Hunting==true)
        {
            agent.destination = player.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Hunting = true;
            Debug.Log("Hunting");

        }
        
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            Hunting = false;
            NavTarget.TargetReached = true;
            Debug.Log("Hunting ended");

        }
        
    }
}
