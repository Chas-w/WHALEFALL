using TMPro;
using UnityEngine;

public class PlayerShootingStart : MonoBehaviour
{
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
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            //var selectionRenderer = selection.GetComponent<Renderer>();

            if (selection.CompareTag("Enemy"))
            {
                isLooking = true;
                _selection = selection;
            }

        }


        if (isLooking)
        {
            if (Input.GetMouseButtonDown(0) && _selection != null)
            {
                _selection.gameObject.GetComponent<EnemyPartInfo>().GotShot();
            }

        }

    }
}
