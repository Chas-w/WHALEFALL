using UnityEngine;

public class Flock : MonoBehaviour
{

    float speed; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(FlockManager.FM.minSpeed, FlockManager.FM.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        ApplyRules();
       this.transform.Translate(speed * Time.deltaTime, 0,0);
    }

    void ApplyRules()
    {
        GameObject[] school;
        school = FlockManager.FM.allFish;

        Vector3 vCenter = Vector3.zero; 
        Vector3 vAvoid = Vector3.zero;

        float gSpeed = .01f; //group speed
        float nDistance; // neighbor distance
        float groupSize = 0;

        foreach(GameObject fish in school)
        {
            if (fish != this.gameObject)
            {
                nDistance = Vector3.Distance(fish.transform.position, this.transform.position);
                if (nDistance <= FlockManager.FM.neighborDistance)
                {
                    vCenter += fish.transform.position;
                    groupSize++;

                    if (nDistance < .01f) 
                    {
                        vAvoid = vAvoid + (this.transform.position - fish.transform.position);
                    }

                    Flock anotherFlock = fish.GetComponent<Flock>();
                    gSpeed += anotherFlock.speed; 
                }
            }
        }

        if (groupSize > 0)
        {
            vCenter = vCenter/groupSize;
            speed = gSpeed/groupSize;

            Vector3 direction = (vCenter + vAvoid) - transform.position; 
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, 
                                                     Quaternion.LookRotation(direction), 
                                                     FlockManager.FM.rotationSpeed * Time.deltaTime);
            }
        }

    }
}
