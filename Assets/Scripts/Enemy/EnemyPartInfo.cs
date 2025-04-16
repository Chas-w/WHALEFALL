using UnityEditor;
using UnityEngine;

public class EnemyPartInfo : MonoBehaviour
{

    [SerializeField] GameObject enemyBody;
    [SerializeField] bool isHead;

    string bodyPart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isHead) bodyPart = "head"; else bodyPart = "body";
        enemyBody.GetComponent<EnemyBehavior>().enemyBodyMesh = this.GetComponent<MeshRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        //if(isHead) this.transform.position = new Vector3(enemyBody.transform.position.x, enemyBody.transform.position.y + 2, enemyBody.transform.position.z);
    }

    public void GotShot()
    {
        enemyBody.GetComponent<EnemyBehavior>().PartGotShot(bodyPart);
    }

    public void SetBody(GameObject body)
    {
        enemyBody = body;
    }
}
