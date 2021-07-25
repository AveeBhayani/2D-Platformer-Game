using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public int transition;
    public float jump;
    public bool grounded;

    public ScoreController ScoreController;
    public GameOverController GameOverController;
    public LivesController LivesController;

    private Rigidbody2D rigid;

    public void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    public void KillPlayer()
    {
        GameOverController.PlayerDied();
        //this.enabled = false;
        LivesController.LifeReducer();
    }

    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal,vertical);
        PlayMovementAnimation(horizontal,vertical);
        CrouchAnimation();
    }

    public void PickUpKey()
    {
        ScoreController.IncreaseScore(10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            grounded = false;
        }
    }

    private void MoveCharacter(float horizontal,float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if(Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rigid.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void PlayMovementAnimation(float horizontal,float vertical)
    {
        // Run Animation
        if (grounded == true)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
        }
        
        Vector3 scale = transform.localScale;

        if(horizontal < 0f)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(horizontal > 0f)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    public void CrouchAnimation()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }

    }
}
