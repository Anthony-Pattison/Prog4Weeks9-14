using UnityEngine;

public class gunUpGrade : MonoBehaviour
{
    public int newClipAmount;
    public onScreenText itemText;
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
        player.GetComponent<playerWeapon>().clipMax = newClipAmount;
        player.GetComponent<playerWeapon>().currentAmmo = newClipAmount;
        EventCore.EV_upgradePickUp.Invoke(itemText);
    }
}
