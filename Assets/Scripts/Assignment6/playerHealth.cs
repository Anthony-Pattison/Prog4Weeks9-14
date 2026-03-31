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
    }
    void takeDamage(float incomingDamage)
    {
        playerHeath.value -= incomingDamage;
    }
}
