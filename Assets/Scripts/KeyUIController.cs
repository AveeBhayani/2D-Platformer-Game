using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUIController : MonoBehaviour
{
    public GameObject[] KeysUI;
    public Animator animator;
    public int Key;

    public void KeyReducer()
    {
        Debug.Log("Test");
        Key -= 1;
        
        //animator.SetBool("Animation", true);
        Destroy(KeysUI[3-Key].gameObject);          
    }
}



