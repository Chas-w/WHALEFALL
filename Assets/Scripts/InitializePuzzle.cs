using Unity.Cinemachine;
using UnityEngine;

public class InitializePuzzle : MonoBehaviour
{

    [SerializeField] GameObject puzzleHolder;
    [SerializeField] GameObject puzzleCamera;
    bool hasStarted;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puzzleHolder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPuzzle()
    {
        puzzleHolder.SetActive(true);
        hasStarted = true;
        puzzleCamera.SetActive(true);
        puzzleCamera.GetComponent<CinemachineCamera>().Priority = 10;

        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;

    }


}
