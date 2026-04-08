using System.Collections;
using Unity.Collections;
using UnityEngine;

public class itemPickUp : MonoBehaviour
{
    public bool isAmmo;
    public bool isHealth;

    public float ammoIncreaseValue;
    public float healthIncreaseValue;

    public bool rotate = true;
    public float rotateAmount = 0.5f;
    public float rotateWaitAmount = 0.05f;
    eventCore EventCore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        if(rotate)
            StartCoroutine(spinPickUp());
    }

    IEnumerator spinPickUp()
    {
        while (true)
        {
            transform.eulerAngles += new Vector3(0,rotateAmount,0);
            yield return new WaitForSeconds(rotateWaitAmount);
        }
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
