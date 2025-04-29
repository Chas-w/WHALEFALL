using UnityEngine;
using Unity.Cinemachine;

public class ToPuzzle : MonoBehaviour
{

    [SerializeField] GameObject PuzzleManager;
    [SerializeField] CinemachineCamera puzzleCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PuzzleManager.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PuzzleManager.SetActive(true);
        puzzleCamera.Priority = 10;
    }


}
