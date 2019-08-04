using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BouncingSphere : MonoBehaviour
{

    public float speed;

    public Vector3 movement;

    public bool isActivated = false;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

        if (!isActivated)
        {
            this.GetComponent<Renderer>().enabled = false;
        } 
    }

    // Update is called once per frame
    void Update()
    {

        if (this.isActivated)
        {
            rb.velocity = movement * speed;
        }
    }

    void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.ArrowHandleCap(0, this.transform.position, Quaternion.FromToRotation(Vector3.forward, movement), 1.5f, EventType.Repaint);
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {

            if (contact.otherCollider.gameObject.tag == "Player")
            {
                Destroy(contact.otherCollider.gameObject);
            }
            else if (contact.otherCollider.gameObject.tag != "Floor")
            {
                movement = Vector3.Reflect(movement, contact.normal);
                return;
            }
        }
    }

    public void Activate()
    {
        this.isActivated = true;
        this.GetComponent<Renderer>().enabled = true;
    }
}
