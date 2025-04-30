using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    public Transform firePoint;
    [SerializeField] LayerMask layerMask;
    [SerializeField] SwitchPOV switchPOV;

    private Transform _selection;
    private bool isLooking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (_selection != null)
        {
            _selection = null;
        }
        else
        {
            //While not selected
            isLooking = false;
        }

        RaycastHit hit;

        if(Physics.Raycast(firePoint.position, this.transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            Debug.DrawRay(firePoint.position, this.transform.TransformDirection(Vector3.forward) * hit.distance);
            var selection = hit.transform;
            //var selectionRenderer = selection.GetComponent<Renderer>();

            if (selection.CompareTag("Enemy") || selection.CompareTag("Puzzle") || selection.CompareTag("Lock"))
            {
                isLooking = true;
                _selection = selection;

                Debug.Log("lookingCorrect");
            }

            //Debug.Log("hitSomething");
            //Debug.Log(selection.gameObject.name);

        }

        if (isLooking)
        {
            if (Input.GetMouseButtonDown(0) && _selection != null)
            {
                if (_selection.gameObject.CompareTag("Enemy")) _selection.gameObject.GetComponent<EnemyPartInfo>().GotShot();
                if (_selection.gameObject.CompareTag("Puzzle")) _selection.gameObject.GetComponent<InitializePuzzle>().StartPuzzle();
                if (_selection.gameObject.CompareTag("Lock")) _selection.gameObject.GetComponent<LockBehavior>().UnlockSelf();
            }

        }
    }
}
