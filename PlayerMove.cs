using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController controller;
    Vector3 velocity;
    public bool isGrounded;
    Rigidbody rb;

    public Transform ground;
    public float distance = 0.3f;

    public float speed;
    public float jumpForce;
    public float gravity;

    public LayerMask mask;

    public float egilmeYuksekligi;
    public float normalYukseklik;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        #region hareket
        //hareket

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        MoveRigidbody(move);

        #endregion

        #region ziplama

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

            isGrounded = false;
        }

        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        //{
        //    velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        //}

        #endregion

        #region yerCekimi

        //isGrounded = Physics.CheckSphere(ground.position, distance, mask);

        //if(isGrounded && velocity.y < 0 )
        //{
        //    velocity.y = 0f;
        //}

        //velocity.y += gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);

        #endregion

        #region kosma

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 8;
        }
        else
        {
            speed = 5;
        }
        #endregion

        #region EgilmeAmaCalismio
        //Egilme (calismio)

        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    Debug.Log("egildi");
        //    controller.height = egilmeYuksekligi;
        //}
        //if(Input.GetKeyUp(KeyCode.LeftControl))
        //{
        //    controller.height = normalYukseklik;
        //}
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zemin")
        {
            isGrounded = true;
        }
    }

    private void MoveRigidbody(Vector3 movement)
    {
        Vector3 newPosition = rb.position + movement * speed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }
}
