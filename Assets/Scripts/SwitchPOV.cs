using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchPOV : MonoBehaviour
{
    [Header("Camera Data")]
    public CinemachineCamera isoCam;
    public CinemachineCamera fpCam;

    [Header("Movement Data")]
    [SerializeField] GameObject playerVisualize;
    public PlayerControllerISO playerControllerISO; 
    public PlayerControllerFP playerControllerFP;

    public bool iso;
    public bool triggerFirst;
    public bool FP; 
    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetMouseButton(1) || FP)
        {
            iso = false;
        } else
        {
            iso = true;
        }

        if (triggerFirst)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FP = !FP; 
            }
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        ISOtoFPSwitch(iso);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FP")
        {
            triggerFirst = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "FP")
        {
            triggerFirst = false;
        }
    }
    void ISOtoFPSwitch(bool _switch)
    {
        if (_switch) //isometric view 
        {
            //Camera priority
            isoCam.Priority = 1;
            fpCam.Priority = 0;

            //MOVEMENT CONTROLS
            playerControllerISO.enabled = true;
            playerControllerFP.enabled = false;

            //see player
            playerVisualize.SetActive(true); 
        }
        if (!_switch) //first person view
        {
            //Camera priority
            isoCam.Priority = 0;
            fpCam.Priority = 1;

            //MOVEMENT CONTROLS
            playerControllerISO.enabled = false;
            playerControllerFP.enabled = true;
            playerControllerFP.groundMovementEnabled = false; //when going to FP for the gun, groundmovement isn't enabled by default. 

            //don't see player
            playerVisualize.SetActive(false);
        }
    }

}
