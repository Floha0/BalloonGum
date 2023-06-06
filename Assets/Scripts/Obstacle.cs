using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float speed = 5f;
    private PlayerController playerControllerSc;

    void Start()
    {
        playerControllerSc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
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
