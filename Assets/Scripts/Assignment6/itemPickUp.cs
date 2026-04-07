using Unity.Collections;
using UnityEngine;

public class itemPickUp : MonoBehaviour
{
    public bool isAmmo;
    public bool isHealth;

    public float ammoIncreaseValue;
    public float healthIncreaseValue;

    eventCore EventCore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
    }
    private void OnTriggerEnter(Collider other)
    {
        string colliderName = other.gameObject.name;
        if (isAmmo)
        {
            increaseAmmo(colliderName);
        }
        if (isHealth)
        {
            increaseHealth(colliderName);
        }
        this.gameObject.SetActive(false);
    }
    void increaseAmmo(string name)
    {
        if (name == "Player")
        {
            EventCore.EV_increasePlayerAmmo.Invoke(ammoIncreaseValue);
            return;
        }
    }
    void increaseHealth(string name)
    {
        print(name);
        EventCore.EV_increaseHealth.Invoke(name, healthIncreaseValue);
    }
}
