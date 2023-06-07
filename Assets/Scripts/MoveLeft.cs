using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveLeft : MonoBehaviour
{
    private float speed = 8f;
    private PlayerController playerControllerSc;

    void Start()
    {
        playerControllerSc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerControllerSc.gameOver){   
            transform.Translate(Vector3.right * Time.deltaTime * speed * -1);
            GetComponent<Rigidbody>().MovePosition(transform.position);
        }

        if (transform.position.x < -5 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
