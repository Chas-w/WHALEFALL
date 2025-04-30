using TMPro;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorManager : MonoBehaviour
{

    [SerializeField] CinemachineCamera elevatorCam;
    [SerializeField] GameObject speedRepresentation;
    [SerializeField] GameObject instructions;
    [SerializeField] GameObject player;

    [SerializeField] float upForce;

    bool hasPlayer;
    bool isApplyingForce;
    bool applyingUpForce;
    float verticalSpeed;
    bool deleteInstructions;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speedRepresentation.SetActive(false);
        instructions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(hasPlayer)
        {
            if (!deleteInstructions && Input.GetMouseButtonDown(0))
            {
                speedRepresentation.SetActive(true);
                instructions.SetActive(false);
                deleteInstructions = true;
            }

            if (Input.GetMouseButtonDown(1)) isApplyingForce = true;
            if(Input.GetMouseButtonUp(1)) isApplyingForce = false;

            
            if (Input.GetMouseButtonDown(0)) applyingUpForce = true;
            if (Input.GetMouseButtonUp(0)) applyingUpForce = false;
            

            //if(Input.GetMouseButtonDown(0)) rb.AddForce(Vector3.up * upForce, ForceMode.Impulse);



            speedRepresentation.GetComponent<TextMeshProUGUI>().text = rb.linearVelocity.y.ToString();

            if(rb.linearVelocity.y > 15) player.GetComponent<PlayerHealth>().DestroySelf();
            if (this.transform.position.y > 28) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        
    }

    private void FixedUpdate()
    {
        //if (isApplyingForce) rb.AddForce(Vector3.down * upForce * 2, ForceMode.Force);
        if(applyingUpForce) rb.AddForce(Vector3.up * upForce, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.SetActive(false);
            elevatorCam.Priority = 10;
            hasPlayer = true;
            instructions.SetActive(true);
        }
        
    }
}
