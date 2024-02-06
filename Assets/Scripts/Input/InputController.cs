using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class InputController : MonoBehaviour
{
    [SerializeField] Animator NetAnimator;
    [SerializeField] float NetDelay = 0.3f;
    float timer = 0;
    [SerializeField] GameObject PauseMenu;
    bool paused=false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            PauseMenu.SetActive(!PauseMenu.active);
            var move = GetComponent<FirstPersonController>();
            move.enabled = !move.enabled;
            paused = !paused;
           
            if (paused) 
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else 
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }




        }

        if (paused) { return; }
        if (!(timer >= NetDelay)) { timer +=Time.deltaTime; return; }
        else if(Input.GetMouseButton(0))
        {
            NetAnimator.SetTrigger("Hit");
            timer = 0;
        }
    }


}
