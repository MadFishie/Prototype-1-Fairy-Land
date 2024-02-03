using UnityEngine;

public class PersistantObj : MonoBehaviour
{
    public static PersistantObj Current;


    private void Start()
    {
        if (Current == null) 
        {
            Current = this;
            DontDestroyOnLoad(this);
        }
        
        else if (Current != this)
        {
            
            
                Destroy(Current.gameObject);
            
            
            


           
        }

    }



}
