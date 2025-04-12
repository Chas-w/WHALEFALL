using UnityEngine;

public class PlayerControllerFP : MonoBehaviour
{
    [Header("Input")]
    float moveInput;
    float turnInput;

    [Header("Character")]
    public CharacterController controller;
    [SerializeField] float moveSpeed; 
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
        Movement(); 
    }

    void Movement()
    {
        GroundMovement();
    }

    void GroundMovement()
    {
        Vector3 move = new Vector3(turnInput, 0, moveInput);
        move.y = 0;

        move *= moveSpeed; 
        controller.Move(move * Time.deltaTime);
    }

    void InputManagement()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }
}
