using UnityEngine;

public class changeActiveWithPause : MonoBehaviour
{
    eventCore EventCore;
    void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        EventCore.EV_pauseGame.AddListener(pauseThis);
        EventCore.EV_unPauseGame.AddListener(unPauseThis);
        EventCore.EV_playCameraAnimations.AddListener(pauseThis);
        EventCore.EV_finshCameraAnimation.AddListener(unPauseThis);
    }

    void pauseThis()
    {
        this.gameObject.SetActive(false);
    }

    void unPauseThis()
    {
        this.gameObject.SetActive(true);
    }
}
