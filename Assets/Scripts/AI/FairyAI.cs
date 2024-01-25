using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class FairyAI : MonoBehaviour
{
   public enum Element {Dark,Candy,Forest,IDK }

    [SerializeField] Element ElementType;

    [SerializeField][Range(0,100)] float Speed;

    [SerializeField][Range (0,100)] float Tolerance;




}
