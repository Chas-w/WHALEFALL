using UnityEngine;

public class GatePuzzle : MonoBehaviour
{

    [SerializeField] GameObject[] lockArray;

    [SerializeField] GameObject leftGate;
    [SerializeField] GameObject rightGate;
    [SerializeField] GameObject leftGateFinal;
    [SerializeField] GameObject rightGateFinal;

    bool isLocked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isLocked = true;
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
            if(unlockCount >= lockArray.Length) isLocked = false;

        }

        if(!isLocked)
        {
            if (leftGate.transform.rotation != leftGateFinal.transform.rotation) {
                leftGate.transform.rotation = Quaternion.Lerp(leftGate.transform.rotation, leftGateFinal.transform.rotation, 2 * Time.deltaTime);
                rightGate.transform.rotation = Quaternion.Lerp(rightGate.transform.rotation, rightGateFinal.transform.rotation, 2 * Time.deltaTime);
            } 
        }
    }

    void UnlockSelf()
    {
        isLocked = false;
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
