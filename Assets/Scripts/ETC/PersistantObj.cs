using UnityEngine;

public class PersistantObj : MonoBehaviour
{
    public static PersistantObj Current;


    private void Start()
    {
        if (Current != null) 
        {
            return;
        }
        else 
        {
            Current = this;
            DontDestroyOnLoad(this);
        }

    }



}
