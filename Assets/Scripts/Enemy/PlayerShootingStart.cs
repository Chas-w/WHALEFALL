using TMPro;
using UnityEngine;

public class PlayerShootingStart : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    private Transform _selection;
    private bool isLooking;
    //GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<SwitchPOV>().FP)
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



            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10, layerMask))
            {
                var selection = hit.transform;
                //var selectionRenderer = selection.GetComponent<Renderer>();

                if (selection.CompareTag("Enemy") || selection.CompareTag("Puzzle") || selection.CompareTag("Lock"))
                {
                    isLooking = true;
                    _selection = selection;

                    Debug.Log("lookingCorrect");
                }

                Debug.DrawRay(ray.origin, ray.direction, Color.green, 10);

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


        
}
