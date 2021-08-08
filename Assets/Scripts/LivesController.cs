using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    public GameObject[] LivesUI;
    public Animator animator;
    public GameOverController GameOverController;

    public int Life;

    public void LifeReducer()
    {
        Life -= 1;      
        Destroy(LivesUI[4-Life].gameObject, 1);  
        
         if (Life == 0)
        {    
            GameOverController.PlayerDied();
        }
    }
}
