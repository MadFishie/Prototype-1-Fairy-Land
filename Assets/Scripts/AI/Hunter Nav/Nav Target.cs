using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool TargetReached;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hunter"))
        {

            TargetReached = true;
            Debug.Log("Target reset");

        }
    }
}
