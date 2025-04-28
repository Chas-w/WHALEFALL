using UnityEngine;

public class GatePuzzle : MonoBehaviour
{

    [SerializeField] GameObject[] lockArray;
    bool isLocked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocked && Input.GetMouseButtonUp(0))
        {

            float unlockCount = 0;
            for (int i = 0; i < lockArray.Length; i++) {
                if (lockArray[i].GetComponent<LockBehavior>().isLocked == false) unlockCount++;
            }
            if(unlockCount >= lockArray.Length) UnlockSelf();

        }
    }

    void UnlockSelf()
    {
        isLocked = false;
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
