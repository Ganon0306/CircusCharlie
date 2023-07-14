using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerComtroler : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 350f;

    private int jumpCount = 0;
    private bool isGrounded = false;
    
    private bool isDead = false;

    private Rigidbody2D playerRigid = default;
    private Animator animator = default;
    private AudioSource playerAudio = default;

    public int life = 5;
    public float speed = 5f;



    private bool isRun;
    private bool isBack;
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Debug.Assert(playerRigid != null);
        Debug.Assert(animator != null);
        //Debug.Assert(playerAudio != null);
    }

    // Update is called once per frame
    void Update()
    {
        bool charlie = isGrounded;
        if (isDead) { return; }

        animator.SetBool("Ground", isGrounded);
        animator.SetBool("Charlie", charlie);


        if (life == 0)
        {
            Die();
        }
        playerAnimation();

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

        }
      
    }

    public void Jump()
    {
        if (jumpCount < 1)
        {
            jumpCount += 1;
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
            //playerAudio.Play();
        }
        else if (0 < playerRigid.velocity.y)
        {
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }
    }
    private void playerAnimation()
    {
        if (Input.GetKey(KeyCode.D))
        {           
            isRun = true;
            isBack = false;


            animator.SetBool("Run", isRun);
            Debug.Assert(animator != null);


        }
        else if (Input.GetKey(KeyCode.A))
        {
           
            isRun = false;
            isBack = true;
            animator.SetBool("Back", isBack);
            Debug.Assert(animator != null);


        }
        else if (!Input.anyKey)
        {
            isBack = false;
            isRun = false;
            animator.SetBool("Run", isRun);
            animator.SetBool("Back", isBack);

        }
    }
   
    private void Die()
    {
        animator.SetTrigger("Die");
        //playerAudio.clip = deathClip;
        //playerAudio.Play();

        playerRigid.velocity = Vector2.zero;
        isDead = true;

        GameManager.instance.OnPlayerDead();

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("fall") && isDead == false)
        {
            animator.SetTrigger("Die");
            life -= 1;

            SceneManager.LoadScene("SampleScene");

        }
        if (collision.tag.Equals("score") && isDead == false)
        {

        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (0.7f < collision.contacts[0].normal.y)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;

    }

 
}