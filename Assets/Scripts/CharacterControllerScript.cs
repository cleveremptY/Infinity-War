using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterControllerScript : MonoBehaviour
{

    public float maxSpeed = 10f;
    public AudioSource walkSound;

    private bool isFacingRight = true;

    public float jumpForce = 250f;
    public string exсeptionGroup = "";
    public string scrollingGroup = "";
    public Image fullScreen;
    public GameObject Inventory;
    public GameObject Ammo;
    //public GameObject End;
    //public int loadScene;

    public Sprite inventoryImage;

    internal Animator anim;


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
        gameObject.transform.Find(exсeptionGroup).gameObject.transform.Find(scrollingGroup).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed * -0.1f, GetComponent<Rigidbody2D>().velocity.x);
        if (move != 0)
        {   
            if (!walkSound.isPlaying && anim.GetBool("Ground"))
                walkSound.Play(); 
            fullScreen.color = new Color(255, 255, 255, 0);
            //fullScreen.sprite = null;
            Inventory.SetActive(false);
            anim.SetBool("Shoot", false);
        }
        if (move == 0 || anim.GetBool("Ground") == false)
        {
            walkSound.Stop();
        }
        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();

        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

       // bool inv = Input.GetButtonDown("Tab1");

        if (shoot)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //for (int i = 0; i < 450; i++)
            //{
            //    gameObject.GetComponent<Transform>().Rotate(Vector3.up * maxSpeed * Time.deltaTime);
            //}
            //if (anim.GetBool("UseLamp") && this.transform.position.x < End.transform.position.x)
            //{
            //    SceneManager.LoadScene(loadScene);
            //}
            if (anim.GetBool("UsePistol") && Ammo.activeSelf)
            {
                anim.SetBool("Shoot", true);
                Debug.Log("Бах");
                Ammo.SetActive(false);
               // anim.SetBool("Shoot", false);
            }
        }
    }

    private void Update()
    {

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {

            anim.SetBool("Ground", false);
            walkSound.Stop();
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            fullScreen.color = new Color(255, 255, 255, 255);
            fullScreen.sprite = inventoryImage;
            Inventory.SetActive(true);
            Debug.Log("Inventory loaded");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
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

            theScale = gameObject.transform.Find(exсeptionGroup).gameObject.transform.localScale;
            theScale.x *= -1;
            theScale = gameObject.transform.Find(exсeptionGroup).gameObject.transform.localScale = theScale;
        }
    }
}
