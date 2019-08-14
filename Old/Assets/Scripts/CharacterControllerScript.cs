using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{

    public float maxSpeed = 10f;

    private bool isFacingRight = true;
    public float jumpForce = 250f;
    public string exeptionGroup = "";
    public string scrollingGroup = "";

    private Animator anim;


    private bool isGrounded = false;

    public Transform groundCheck;

    private float groundRadius = 0.2f;

    public LayerMask whatIsGround;

	private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        anim.SetBool("Ground", isGrounded);

        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

        if (!isGrounded)
            return;

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (move > 0 && !isFacingRight)
     
            Flip();

        else if (move < 0 && isFacingRight)
            Flip();

        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
            for (int i = 0; i < 450; i++)
            {
                gameObject.GetComponent<Transform>().Rotate(Vector3.up * maxSpeed * Time.deltaTime);
            } 
        }
    }

    private void Update()
    {

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {

            anim.SetBool("Ground", false);

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }

    private void Flip()
    {
       //if (gameObject.name != exeptionGroup)
        {

            isFacingRight = !isFacingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;

            theScale = gameObject.transform.Find(exeptionGroup).gameObject.transform.localScale;
            theScale.x *= -1;
            theScale = gameObject.transform.Find(exeptionGroup).gameObject.transform.localScale = theScale;
        }
    }
}
