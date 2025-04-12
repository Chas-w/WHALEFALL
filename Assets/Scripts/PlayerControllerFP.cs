using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerFP : MonoBehaviour
{

    [Header("Player Data")]
    public float mSpeed;
    [SerializeField] Transform orientation;
    [SerializeField] CharacterController controller;

    [Header("Mouse Data")]
    [SerializeField] float mouseSens;

    float xRotation;
    float yRotation;
    float sensAdjuster = 100f;


    float mX = 0;
    float mZ = 0;

    [Header("Physics")]
    public float gravity = -9.81f;
    [SerializeField] float groundDistance = .4f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;

    /*
    [Header("Audio Data")]
    [SerializeField] AudioSource stepSource;
    [SerializeField] AudioClip[] footsteps;
    [SerializeField] float stepTimerMax;
    */
    Vector3 velocity;

    bool isGrounded;
    float stepTimer;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        GroundMovement();
        MouseMovement(); 
    }

    void GroundMovement()
    {
        //Get input
        mX = Input.GetAxis("Horizontal"); 
        mZ = Input.GetAxis("Vertical");

        Vector3 move = orientation.right * mX + orientation.forward * mZ; //direction we want to move
        controller.Move(move * mSpeed * Time.deltaTime); //move
        //playFootsteps();
    }

    void ApplyGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //check if grounded

        if (isGrounded && velocity.y < 0) //don't fall if grounded
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime; //fall otherwise

        controller.Move(velocity * Time.deltaTime); //implement

    }

    void MouseMovement()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * (mouseSens * sensAdjuster);
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * (mouseSens * sensAdjuster);

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    /*
    private void playFootsteps()
    {
        if (isGrounded && (mX != 0 || mZ != 0))
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0)
            {
                stepSource.PlayOneShot(footsteps[(Random.Range(0, footsteps.Length))]);
                stepTimer = stepTimerMax;
            }
        }
    }
    */
}
