using UnityEngine;

public class uiHandsAnimation : MonoBehaviour
{
    eventCore EventCore;
    public Animator handsAni;
    public string onShootTrigger = "onShoot";
    public string onReloadTrigger = "onReload";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        EventCore.EV_playerShoot.AddListener(playOnShoot);
        EventCore.EV_playerReload.AddListener(playOnReload);
    }

    void playOnShoot()
    {
        handsAni.SetTrigger(onShootTrigger);
    }

    void playOnReload()
    {
        handsAni.SetTrigger(onReloadTrigger);
    }
}
