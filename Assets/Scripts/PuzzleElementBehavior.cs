using UnityEngine;

public class PuzzleElementBehavior : MonoBehaviour
{

    [SerializeField] GameObject mouseTracker;

    public int correctPosition;
    public int currentPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseTracker.transform.position.x < this.transform.position.x + 0.5f && mouseTracker.transform.position.x > this.transform.position.x - 0.5f
            && mouseTracker.transform.position.y < this.transform.position.y + 0.5f && mouseTracker.transform.position.y > this.transform.position.y - 0.5f
            && Input.GetMouseButtonDown(0))
        {
            this.transform.Rotate(0, 0, -90);
            currentPosition += 1;
            if (currentPosition > 3) currentPosition = 0;
            Debug.Log("turned");
        }
    }
}
