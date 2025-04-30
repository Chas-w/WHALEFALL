using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject damageUi;

    int health;
    bool isDamaged;
    float damageTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 3;
        damageUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamaged) {
            damageTimer += Time.deltaTime;

            if(damageTimer > 2)
            {
                damageTimer = 0;
                isDamaged = false;
                damageUi.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !isDamaged)
        {
            damageUi.SetActive(true);
            health--;
            if (health == 0) DestroySelf();
            isDamaged = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void DestroySelf()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
