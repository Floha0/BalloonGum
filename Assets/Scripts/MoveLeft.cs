using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 8f;
    private PlayerController playerControllerSc;

    void Start()
    {
        playerControllerSc = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    void FixedUpdate()
    {
        if (!playerControllerSc.gameOver){   
            transform.Translate(Vector3.right * Time.fixedDeltaTime * speed * -1);
        }

        if (transform.position.x < -5 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
