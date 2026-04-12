using UnityEngine;

public class gunUpGrade : MonoBehaviour
{
    public bool weaponPickUp;
    public gunValue weaponPickUpValue;
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
        if (!weaponPickUp)
        {
            ammoPickUp();
        }
        else
        {
            gunPickUp();
        }

        EventCore.EV_upgradePickUp.Invoke(itemText);
        GetComponent<BoxCollider>().enabled = false;
    }
    void gunPickUp()
    {
        playerObject.GetComponent<playerWeapon>().weaponInventory.Add(weaponPickUpValue);
    }
    void ammoPickUp()
    {
        GameObject player = playerObject;
        gunToLevelUp.maxAmmo = newClipAmount;
        gunToLevelUp.currentAmmo = newClipAmount;
    }
}
