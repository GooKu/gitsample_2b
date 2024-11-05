using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private SpriteRenderer render;
    private Animator anim;
    private Rigidbody2D rig;

    private bool isJumping = false;
    private float jumpTime;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        //Debug.Log("Start");
        //        rig.velocity = new Vector2(10, 0);
        //rig.AddForce(new Vector2(100, 0)); // => rig.AddForce(new Vector2(100, 0) * Time.deltaTime, ForceMode2D.Impulse);
        //anim.Play("Jump");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            render.flipX = false;
            anim.SetBool("Moving", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            render.flipX = true;
            anim.SetBool("Moving", true);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("Moving", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            //rig.AddForce(new Vector2(0, 100), ForceMode2D.Impulse);
            //isJumping = true;
            //jumpTime = 0;
            //anim.SetBool("Jumping", true);
            Jump();
        }
    }

    public void Jump()
    {
        rig.AddForce(new Vector2(0, 100), ForceMode2D.Impulse);
        isJumping = true;
        jumpTime = 0;
        anim.SetBool("Jumping", true);
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            jumpTime += Time.fixedDeltaTime;
            if (jumpTime > .1f && rig.Cast(Vector2.down, new RaycastHit2D[10], .1f) > 0)
            {
                isJumping = false;
                anim.SetBool("Jumping", false);
                anim.Play("Idle");
            }
        }
    }
}
