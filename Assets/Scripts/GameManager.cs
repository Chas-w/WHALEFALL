using UnityEditor.SearchService;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Door Data")]
    public string nextRoom; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
