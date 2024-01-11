using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //movement variables
    private float horizontalInput;
    public float speed;
    private float verticalInput;
    public bool canJump;
    public float jumpHeight = 10.0f;

    //Components
    private Rigidbody2D rb;
    private Animator anim;

    private bool using2d;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        using2d = true;
        canJump = true;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");
        /*if (horizontalInput != 0)
        {
            if (!anim.isPlaying)
            {
                anim.Play("Run");
            }
        }*/

        //Movement for 2D
        if (using2d)
        {
            //jump
            if (canJump && Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                canJump = false;
            }
        }
        //Movement for 2.5D
        else
        {
            verticalInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, verticalInput*speed);
        }
    }

    public void onCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("2dGround"))
        {
            canJump = true;
        }
    }
}
