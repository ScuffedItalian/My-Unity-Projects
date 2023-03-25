using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 10f; //Speed of the player
    public float torque = 10f; //Torque of the player
    public float speedPlus = 20f;
    public float jumpFor = 10f;
    public float jumpHeight = 2f;
    public bool isJumping = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity += new Vector3(0f, jumpFor, 0f);
            isJumping = true;
        }

        if (transform.position.y >= jumpHeight)
        {
            isJumping = false;
        }

        if (isJumping && rb.velocity.y < 0.1f)
        {
            isJumping = false;
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.A))
        {
            movement = new Vector3(0, 0, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement = new Vector3(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            movement = new Vector3(0, 0, speedPlus * Time.deltaTime);
        }

        rb.MovePosition(transform.position + movement);

        if (movement.magnitude > 7)
        {
            Debug.Log("adawhwaawd");
            // Vector3 torqueDirection = new Vector3(movement.z, 0, -movement.x);
            // rb.AddTorque(torqueDirection * torque);
        }

        if (Mathf.Abs(transform.position.y - 7f) < 0.1f)
        {
            rb.AddForce(Vector3.down * 3f, ForceMode.Impulse);
            Debug.Log("YAY");
        }
    }


}
