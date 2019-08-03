using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            rb.velocity = movement * speed;
        }
    }
}
