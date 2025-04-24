using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
//tutorial referenced: https://learn.unity.com/tutorial/flocking#6317c572edbc2a2290a9e352

public class FlockManager: MonoBehaviour
{
    public static FlockManager FM; 
    public GameObject fishPrefab;
    public int fishNumb = 20;

    public GameObject[] allFish;

    public Vector3 swimLimits = new Vector3(5, 5, 5);

    [Header("Fish Settings")]
    [Range(0f, 5f)]
    public float minSpeed;
    [Range(0f, 5f)]
    public float maxSpeed;
    [Range(1f, 10f)]
    public float neighborDistance;
    [Range(1f, 5f)]
    public float rotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        allFish = new GameObject[fishNumb];

        for (int i = 0; i < allFish.Length; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
                                                                Random.Range(-swimLimits.y, swimLimits.y),
                                                                 Random.Range(-swimLimits.z, swimLimits.z)); //fish are relative to where flock manager is

            allFish[i] = Instantiate(fishPrefab, pos, Quaternion.identity);
        }
        FM = this; 
    }

    // Update is called once per frame
    void Update()
    {

    }
}
