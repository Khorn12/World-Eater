using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{



 public float speed;
 private float moveInput;

 private Rigidbody2D rb;
 private Animator anim;
 public bool facingRight = true;
 public float jumpForce = 7f;
 

   [Header("Sounds")]
    [SerializeField] private AudioClip jumpSound;






 private void Start()
 {
     anim = GetComponent<Animator>();
     rb = GetComponent<Rigidbody2D>();
    

 }


 private void FixedUpdate()
 {
     moveInput = Input.GetAxis("Horizontal");
     rb.velocity = new Vector2(moveInput * speed,rb.velocity.y);
     if(moveInput == 0)
     {
         anim.SetBool("isRunning",false);

     }
     else
     {
         anim.SetBool("isRunning", true);

     }
     if(facingRight == false && moveInput > 0)
     {
         Flip();
     }
     else if (facingRight == true && moveInput < 0)
     {
         Flip();
     }
     void Flip()
     {
         facingRight = !facingRight;
         transform.Rotate(0f,180f,0f);
     }
 }
     
 
 private void Update()
 {
   Jump();
   
   CheckingGround();
  

 }

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
    


