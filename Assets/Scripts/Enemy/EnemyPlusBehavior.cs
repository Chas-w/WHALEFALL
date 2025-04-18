using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPlusBehavior : MonoBehaviour
{

    [Header("GameObjects")]
    [SerializeField] GameObject enemyPrefab;
    //[SerializeField] GameObject headPrefab;
    [SerializeField] Transform rightEnemySpawn;
    [SerializeField] Transform leftEnemySpawn;
    [SerializeField] GameObject healthUi;

    [Header("Materials")]
    [SerializeField] Material first;
    [SerializeField] Material second;
    [SerializeField] Material third;
    [SerializeField] Material hit;
    [SerializeField] Material normal;


    //Components
    Rigidbody body;
    public SkinnedMeshRenderer enemyBodyMesh;
    NavMeshAgent agent;

    //Private
    int enemyIteration;
    int currentHealth;
    float hitTimer;
    bool isHit;
    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
        SpawnAsClone(enemyIteration);

        player = GameObject.FindGameObjectWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            hitTimer += Time.deltaTime;

            if (hitTimer > 0.5f)
            {
                hitTimer = 0;
                isHit = false;
                enemyBodyMesh.material = normal;
            }
        }

        agent.SetDestination(player.transform.position);
        healthUi.GetComponent<TextMeshPro>().text = currentHealth.ToString();
    }


    public void PartGotShot(string bodyPart)
    {
        if (bodyPart == "body")
        {
            currentHealth--;

            isHit = true;
            enemyBodyMesh.material = hit;

            if (currentHealth <= 0)
            {
                if (enemyIteration >= 3) Destroy(gameObject); else SplitSelf();
            }
        }
        else if (bodyPart == "head")
        {
            if (enemyIteration != 0) Destroy(this.gameObject);
            else
            {
                currentHealth--;

                isHit = true;
                enemyBodyMesh.material = hit;

                if (currentHealth <= 0)
                {
                    SplitSelf();
                }
            }
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
        switch (currentIteration)
        {
            case 0:
                enemyBodyMesh.material = normal;
                currentHealth = 5;
                enemyIteration = currentIteration;
                break;
            case 1:
                enemyBodyMesh.material = first;
                currentHealth = 4;
                enemyIteration = currentIteration;
                break;
            case 2:
                enemyBodyMesh.material = second;
                currentHealth = 2;
                enemyIteration = currentIteration;
                break;
            case 3:
                enemyBodyMesh.material = third;
                currentHealth = 1;
                enemyIteration = currentIteration;
                break;
        }
    }
}
