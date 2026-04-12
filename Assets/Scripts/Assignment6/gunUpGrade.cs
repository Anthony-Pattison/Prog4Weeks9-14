using UnityEngine;

public class gunUpGrade : MonoBehaviour
{
    public int newClipAmount;
    public onScreenText itemText;
    public gunValue gunToLevelUp;
    public GameObject playerObject;
    eventCore EventCore;
    void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        GameObject player = playerObject;
        gunToLevelUp.maxAmmo = newClipAmount;
        gunToLevelUp.currentAmmo = newClipAmount;
        EventCore.EV_upgradePickUp.Invoke(itemText);
    }
}
