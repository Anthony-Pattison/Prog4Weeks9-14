using UnityEngine;

public class startCameraAnimations : MonoBehaviour
{
    eventCore eventCore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
            return;
        eventCore.EV_playCameraAnimations.Invoke();
        GetComponent<BoxCollider>().enabled = false;
    }

}
