using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 10f; //Speed of the player
    public float torque = 10f; //Torque of zeee player
    public float speedPlus = 20f;
    private Rigidbody rb; //Rigidbody var
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Getting the RigidBody component
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.D))
        {
            movement = new Vector3(0, 0, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement = new Vector3(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            movement = new Vector3(0, 0, speedPlus * Time.deltaTime);
        }
        
        rb.MovePosition(transform.position + movement);
        
        if (movement.magnitude > 0)
        {
            Vector3 torqueDirection = new Vector3(movement.z, 0, -movement.x);
            rb.AddTorque(torqueDirection * torque);
        }
        
    }
}
