using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorHandle : MonoBehaviour
{
    //Game manager will store what scene we're coming from and where we are going

    int numbRotations = 0;
    int expectedRotations = 3;

    [SerializeField] float waitTransition = 9;
    public GameManager gameManager; 


    public Animator animator;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        OpenDoor(numbRotations);
    }

    void OpenDoor(int rotations)
    {
        rotations = animator.GetInteger("DoorAnim");

        if (rotations < expectedRotations && Input.GetMouseButtonDown(0)) //the door hasn't been opened up
        {

            if (rotations == 0) //first time rotating handle; 
            {
                animator.SetInteger("DoorAnim", 1); 
            }
            if (rotations == 1) //first time rotating handle; 
            {
                animator.SetInteger("DoorAnim", 2);
            }
            if (rotations == 2) //first time rotating handle; 
            {
                animator.SetInteger("DoorAnim", 3);
            }
        }
        if (rotations == 3)
        {
            waitTransition -= Time.deltaTime; //wait for animation to playout
        }
        if (waitTransition < 0)
        {
            SceneManager.LoadScene(gameManager.nextRoom);
            //Debug.Log("nextScene");
        }

    }



}
