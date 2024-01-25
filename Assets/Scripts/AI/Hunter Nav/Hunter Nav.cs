using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HunterNav : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject NavPoints;
    private List<Transform> NavPointList=new List<Transform>();
    private int NavPointCount;
    private bool Hunting = false;
    [SerializeField] private Transform player;
    private NavMeshAgent agent;


    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        NavPointCount = NavPoints.transform.childCount;
        //Debug.Log(NavPointCount);
        //var navItems = NavPoints.GetComponentInChildren<Transform>();
        //NavPointList = navItems;
        
       foreach (Transform child in NavPoints.transform)
        {
            Debug.Log(child);
            NavPointList.Add(child);
            Debug.Log("point added");
        }
        
        /*for (int i = 0; i < NavPointCount; i++)
        {
            //Debug.Log(i);
            Debug.Log(NavPoints.transform.GetChild(i));
            NavPointList.Add(NavPoints.transform.GetChild(i));
            Debug.Log("Child added");

        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (NavTarget.TargetReached==true&&Hunting==false)
        {

            agent.destination = NavPointList[Random.Range(0, NavPointCount)].position;
            NavTarget.TargetReached = false;

        }
        if (Hunting==true)
        {
            agent.destination = player.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Hunting = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Hunting = false;
        NavTarget.TargetReached = true;
    }
}
