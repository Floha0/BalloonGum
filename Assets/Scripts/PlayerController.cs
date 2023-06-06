using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private float moveHorizontal;
    private float speed = 8f;
    private float jumpForce = 50f;
    private bool isOnGround = true;
    public bool gameOver = false;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        // Physics.gravity *= gravityModifier;
    }

    void Update() {
        moveHorizontal = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed * moveHorizontal);
        jump();
    }

    private void jump(){
        if (Input.GetKeyDown(KeyCode.W) && isOnGround){
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Collided Something.");
        if (other.gameObject.CompareTag("Ground")){
            isOnGround = true;
        }
        if (other.gameObject.CompareTag("Obstacle")){
            gameOver = true;
        }
    }

}
