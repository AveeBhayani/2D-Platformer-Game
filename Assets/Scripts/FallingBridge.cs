using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBridge : MonoBehaviour
{
    private Rigidbody2D Rigid;

    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Invoke("DropPlatform", 0.3f);
            Destroy(gameObject, 2f);
        }
    }

    void DropPlatform()
    {
        Rigid.isKinematic = false;
    }
}
