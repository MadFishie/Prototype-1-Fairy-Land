using System.Collections;
using System.Collections.Generic;
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
        else { timer = 0; }

        if (Input.GetMouseButton(0))
        {
            NetAnimator.SetTrigger("Hit");
           
        }
    }


}
