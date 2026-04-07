using UnityEngine;

public class enemyHealthScript : MonoBehaviour
{
    eventCore EventCore;
    public float healthValue;
    float currentHeath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        EventCore.EV_enemyDamage.AddListener(takeDamage);
        EventCore.EV_increaseHealth.AddListener(increaseThisHealth);
        currentHeath = healthValue;
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
            this.gameObject.SetActive(false);
        }
    }
}
