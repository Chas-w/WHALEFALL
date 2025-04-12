using UnityEngine;
using UnityEngine.Events;
//tutorial referenced https://youtu.be/b7Yf6BFx6js?si=z0eM-TZEf6C35qA7
public class Interactable : MonoBehaviour
{
    public UnityEvent onInteraction; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Interact()
    {
        onInteraction.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
