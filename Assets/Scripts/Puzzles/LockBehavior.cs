using UnityEngine;

public class LockBehavior : MonoBehaviour
{

    public bool isLocked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockSelf()
    {
        isLocked = false;
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
