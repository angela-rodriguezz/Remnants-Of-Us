using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSoundEffect;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
        

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 14f);
            jumpSoundEffect.Play();
        }

        UpdateAnimationUpdate();
        
    }

    private void UpdateAnimationUpdate()
    {
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;

        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            
            sprite.flipX = false;
        }
        else
        {
            anim.SetBool("running", false);
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
