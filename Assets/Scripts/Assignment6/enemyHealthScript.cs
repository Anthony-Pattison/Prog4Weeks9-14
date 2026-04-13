using UnityEngine;

public class enemyHealthScript : MonoBehaviour
{
    public GameObject golem;
    eventCore EventCore;
    public float healthValue;
    float currentHeath;
    Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        playerTransform = GameObject.Find("Player").transform;
        EventCore.EV_enemyDamage.AddListener(takeDamage);
        EventCore.EV_increaseHealth.AddListener(increaseThisHealth);
        currentHeath = healthValue;
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            Debug.DrawRay(transform.position, (playerTransform.position - transform.position).normalized, Color.red, 10);
        }
    }

    void increaseThisHealth(string name,float increaseValue)
    {
        if(name != this.gameObject.name)
            return;
        currentHeath += increaseValue;
    }

    void takeDamage(string targetName, float incomingDamage)
    {
        if(targetName != this.gameObject.name)
            return;
        GetComponent<ParticleSystem>().Play();
        currentHeath -= incomingDamage;
        if (currentHeath <= 0)
        {
            if(golem != null)
                golem.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
