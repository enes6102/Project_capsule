using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrols : MonoBehaviour
{

    [Header("Movement")]

    Rigidbody rb;
    public float movementSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask Ground;
    bool grounded;




    float verticalInput;
    float horizontalInput;

    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform Groundcheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpSound;

    Vector3 moveDirection;

    public Transform orientation;

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

        ///grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, Ground);


       
        rb.drag = groundDrag;
        


        MyInput();

        if (Input.GetButtonDown("Jump")&&IsGrounded())
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(Groundcheck.position, .1f, ground);
    }

    private void MovePlayer()
    {
        // calculate move direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);

    }
}

