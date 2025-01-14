using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public KeyUIController KeyUIController;
    public ParticleSystem Collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.PickUpKey();
            KeyUIController.KeyReducer();
            Destroy(gameObject, 0.02f);
            Collected.Play();           
        }
    }
}
