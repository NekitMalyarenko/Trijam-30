using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float timer;

    public float speed;

    public GameController gameController;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameController.InitGame();
        gameController.NextLevel(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey("w"))
        {
            movement.z = 1.0f;
        }

        if (Input.GetKey("s"))
        {
            movement.z = -1.0f;
        }

        if (Input.GetKey("d"))
        {
            movement.x = 1.0f;
        }

        if (Input.GetKey("a"))
        {
            movement.x = -1.0f;
        }


        if (movement != Vector3.zero)
        {
            //print(rb.velocity);
            rb.MovePosition(rb.transform.position +  movement * speed);
        }
    }

    private void Update()
    {

        if (timer >= 0 && rb.velocity == Vector3.zero)
        {
            timer -= Time.deltaTime;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {

            if (contact.otherCollider.gameObject.tag == "Finish")
            {
                gameController.NextLevel(gameObject);
                return;
            }
        }
    }

    void OnDestroy()
    {
        Application.Quit();
    }
}
