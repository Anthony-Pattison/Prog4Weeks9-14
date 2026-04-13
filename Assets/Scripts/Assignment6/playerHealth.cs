using UnityEngine;
using UnityEngine.Rendering;

public class playerHealth : MonoBehaviour
{
    public valueObject playerHeath;
    eventCore eventCore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        eventCore.playerDamage.AddListener(takeDamage);
        eventCore.EV_increaseHealth.AddListener(increaseThisHealth);
        eventCore.playerDamage.AddListener(checkHealth);
    }

    void checkHealth(float nothin)
    {
        if(playerHeath.value <= 0)
        {
            GetComponent<playerScript>().respawnPlayer();
        }
    }
    void increaseThisHealth(string name, float increaseValue)
    {
        if (name != this.gameObject.name)
            return;
        playerHeath.value += increaseValue;
    }

    void takeDamage(float incomingDamage)
    {
        playerHeath.value -= incomingDamage;
    }
}
