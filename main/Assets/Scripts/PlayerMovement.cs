using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0f;
    public LayerMask groundMask;
    bool isGrounded;
    public AudioSource audioSource;
    private Vector3 moveDetector;
    private float stopTimer = 0f;
    public static bool StopMusic = false;
    Vector3 velocity;
    // Update is called once per frame

    void Start()
    {
        audioSource = audioSource.GetComponent<AudioSource>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;



        if (moveDetector != controller.transform.position)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else if (StopMusic || moveDetector == controller.transform.position)
        {
            audioSource.Stop();
            StopMusic = false;
        }
        moveDetector = controller.transform.position;


        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


    }
}
