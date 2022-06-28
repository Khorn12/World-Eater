using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
 public  Rigidbody2D rb;
 public  Vector2 moveVector;
 public float speed = 4f;
 public Animator anim;
 public SpriteRenderer sr;

 
    [Header("Sounds")]
    [SerializeField] private AudioClip jumpSound;

 
 void Start()
 {
     rb = GetComponent<Rigidbody2D>();
     anim = GetComponent<Animator>();
     sr = GetComponent<SpriteRenderer>();
 }

 void Update()
 {
   walk();
   
   Reflect();
    Jump();
    CheckingGround();
 }
 
   public bool faceRight =true;

 void walk()
 {
     moveVector.x = Input.GetAxis("Horizontal");
     anim.SetFloat("moveX",Mathf.Abs(moveVector.x));
     rb.velocity = new Vector2(moveVector.x * speed , rb.velocity.y);
 }
   void Reflect()
   {
       if((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
       {
           transform.localScale *= new Vector2( -1, 1);
           faceRight = !faceRight;
       }
   }

   public float jumpForce = 7f;
   void Jump()
   {
       if(Input.GetKeyDown(KeyCode.Space) && onGround)
       {
           //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
           rb.AddForce(Vector2.up * jumpForce);
            SoundManager.instance.PlaySound(jumpSound);

       }
   }

   public bool onGround;
   public Transform GroundCheck;
   public float checkRadius = 0.5f;
   public LayerMask Ground;

   void CheckingGround()
   {
       onGround = Physics2D.OverlapCircle(GroundCheck.position,checkRadius, Ground);
       anim.SetBool("onGround", onGround);
   }

    

}
