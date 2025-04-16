using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    /*
    [Header("Physics")]
    public float gravity = -9.81f;
    [SerializeField] float groundDistance = .4f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    
    */

    [Header("GameObjects")]
    [SerializeField] GameObject enemyPrefab;
    //[SerializeField] GameObject headPrefab;
    [SerializeField] Transform rightEnemySpawn;
    [SerializeField] Transform leftEnemySpawn;

    [Header("Materials")]
    [SerializeField] Material first;
    [SerializeField] Material second;
    [SerializeField] Material third;
    [SerializeField] Material hit;
    [SerializeField] Material normal;


    //Components
    Rigidbody body;
    public MeshRenderer enemyBodyMesh;

    //Private
    int enemyIteration;
    int currentHealth;
    float hitTimer;
    bool isHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
        SpawnAsClone(enemyIteration);
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            hitTimer += Time.deltaTime;

            if(hitTimer > 0.5f)
            {
                hitTimer = 0;
                isHit = false;
                this.GetComponent<MeshRenderer>().material = normal;
            }
        }
    }
    

    public void PartGotShot(string bodyPart)
    {
        if(bodyPart == "body")
        {
            currentHealth--;

            isHit = true;
            this.GetComponent<MeshRenderer>().material = hit;

            if (currentHealth <= 0) { 
                if(enemyIteration >= 3) Destroy(gameObject); else SplitSelf();
            }
        } else if(bodyPart == "head")
        {
            Destroy(this.gameObject);
            Debug.Log("HeadShot");
        }
    }

    private void SplitSelf()
    {
        GameObject leftEnemy = GameObject.Instantiate(enemyPrefab, leftEnemySpawn.position, Quaternion.identity);
        leftEnemy.GetComponent<EnemyBehavior>().SpawnAsClone(enemyIteration + 1);
        //GameObject leftHead = GameObject.Instantiate(enemyPrefab, leftEnemySpawn.position, Quaternion.identity);
        //leftHead.GetComponent<EnemyPartInfo>().SetBody(leftEnemy.gameObject);

        GameObject rightEnemy = GameObject.Instantiate(enemyPrefab, rightEnemySpawn.position, Quaternion.identity);
        rightEnemy.GetComponent<EnemyBehavior>().SpawnAsClone(enemyIteration + 1);
        //GameObject rightHead = GameObject.Instantiate(enemyPrefab, rightEnemySpawn.position, Quaternion.identity);
        //rightHead.GetComponent<EnemyPartInfo>().SetBody(rightEnemy.gameObject);

        Destroy(this.gameObject);
    }
    public void SpawnAsClone(int currentIteration)
    {
        switch(currentIteration)
        {
            case 0:
                this.GetComponent<MeshRenderer>().material = normal;
                currentHealth = 5;
                enemyIteration = currentIteration;
                break;
            case 1:
                this.GetComponent<MeshRenderer>().material = first;
                currentHealth = 4;
                enemyIteration = currentIteration;
                break;
            case 2:
                this.GetComponent<MeshRenderer>().material = second;
                currentHealth = 2;
                enemyIteration = currentIteration;
                break;
            case 3:
                this.GetComponent<MeshRenderer>().material = third;
                currentHealth = 1;
                enemyIteration = currentIteration;
                break;
        }
    }



    /*
    void ApplyGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //check if grounded

        if (isGrounded && velocity.y < 0) //don't fall if grounded
        {
            velocity.y = -2f;
        }

        body.AddForce(velocity.y gravity * Time.deltaTime, ForceMode.Force); //fall otherwise

    }
    */
}
