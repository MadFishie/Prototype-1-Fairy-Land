using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HunterNav :AudioWrapper
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
    [SerializeField] Animator WolfAnimator;
    [SerializeField] AudioClip HeartBeat,HuntEnded;
    [SerializeField][Range(0, 1)] float HeartBeatVol = 0.3f;
    [SerializeField] private float MovmentSpeed;
    [SerializeField] private float HuntingSpeed;


    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        NavPointCount = NavPoints.transform.childCount;
        NavTarget.TargetReached = false;
        agent.speed = MovmentSpeed;


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
            if (!Hunting) { SwapOutAudio(HeartBeat,HeartBeatVol); }
            Hunting = true;
            Debug.Log("Hunting");
          
            WolfAnimator.SetTrigger("Hunting");
            agent.speed = HuntingSpeed;

        }
        
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (Hunting) { SwapOutAudio(HuntEnded, 0.124f); }
            Hunting = false;
            NavTarget.TargetReached = true;
            Debug.Log("Hunting ended");
            WolfAnimator.SetTrigger("NotHunting");
            agent.speed = HuntingSpeed;

        }
        
    }
}
