using UnityEngine;
using UnityEngine.Rendering;

public class damagePlayer : MonoBehaviour
{
    eventCore EventCore;
    public float damge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            damagePlayerFists();
    }
    void damagePlayerFists()
    {
        EventCore.playerDamage.Invoke(damge);
    }
}
