using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private float moveHorizontal;
    private float speed = 8f;
    private float jumpForce;
    private bool isOnGround = true;
    public bool gameOver = false;
    private Rigidbody playerRb;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        jumpForce = playerRb.mass * 7.5f;
        // Physics.gravity *= gravityModifier;

    }

    void Update() {
        moveHorizontal = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if (!gameOver)
        {
            transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed * moveHorizontal);   
            jump();
        }
    }

    private void jump(){
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision Collider) {
        Debug.Log(Collider.gameObject.name);
        if (Collider.gameObject.CompareTag("Ground")){
            isOnGround = true;
        }
        if (Collider.gameObject.CompareTag("Obstacle")){
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }

}
