using UnityEngine;
using UnityEngine.SceneManagement;

public class ToDoorScene : MonoBehaviour
{
    [Header("Higher powers")]
    public GameManager gameManager;
    public SwitchPOV switcher;

    [Header("Door data")]
    public string sceneToQueue;
    [SerializeField] bool canDoor; 
    

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        switcher = GameObject.Find("POVSwitcher").GetComponent<SwitchPOV>();
    }

    // Update is called once per frame
    void Update()
    {
        TriggerDoor(); 

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canDoor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canDoor = false;
        }
    }

    void TriggerDoor()
    {
        gameManager.nextRoom = sceneToQueue;

        if (canDoor && switcher.iso) //if door is interactable and we're in isometric view
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("DoorScene");
            }
        }
        if (canDoor && !switcher.iso) //if door is interactable and we're in FP view
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("DoorScene");
            }
        }
    }
}
