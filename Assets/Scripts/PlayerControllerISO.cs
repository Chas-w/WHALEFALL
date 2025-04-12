using UnityEngine;
//https://youtu.be/fKiXllLuIUs?si=UlwHvQ1pbXnGyQLL tutorial referenced

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerISO : MonoBehaviour
{
    public Vector3 input;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;


    InputSystem_Actions playerInputActions;
    CharacterController characterController;



    private void Awake()
    {
        playerInputActions = new InputSystem_Actions();
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        playerInputActions.Player.Enable(); 
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;

        GatherInput();

        Move();

        Look();
    }

    void Look()
    {
        
        if (input == Vector3.zero) return;  //if the player isn't moving exit function; 
        Debug.Log("looking");

        Matrix4x4 isometricMatrix = Matrix4x4.Rotate(Quaternion.Euler(0f,90f,0f)); //creating isometric grid for accurate axis turning
        Vector3 multipliedMatrix = isometricMatrix.MultiplyPoint3x4(input);

        Quaternion rotation = Quaternion.LookRotation(multipliedMatrix, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        
    }

    void Move()
    {
        
        Vector3 moveDirection = transform.forward * moveSpeed * input.magnitude * Time.deltaTime;

        characterController.Move(moveDirection);
        


    }

    void GatherInput()
    {
        Vector2 _input = playerInputActions.Player.Move.ReadValue<Vector2>();

        input = new Vector3(_input.x, 0, _input.y);

    }
}
