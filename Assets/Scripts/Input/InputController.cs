using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] Animator NetAnimator;
    [SerializeField] float NetDelay = 0.3f;
    float timer = 0;
    [SerializeField] BoxCollider NetCheck;


    private void Update()
    {
        if (!(timer >= NetDelay)) { timer +=Time.deltaTime; return; }
        else if(Input.GetMouseButton(0))
        {
            NetAnimator.SetTrigger("Hit");
            timer = 0;
        }
    }


}
