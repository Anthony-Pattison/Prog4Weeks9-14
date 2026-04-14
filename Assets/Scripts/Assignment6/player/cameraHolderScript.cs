using UnityEngine;

public class cameraHolderScript : MonoBehaviour
{
    public Transform playerOrientation;
    eventCore EventCore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        EventCore.EV_pauseGame.AddListener(pauseThis);
        EventCore.EV_unPauseGame.AddListener(unPauseThis);
    }
    void pauseThis()
    {
        this.enabled = (false);
    }

    void unPauseThis()
    {
        this.enabled = (true);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = playerOrientation.position;
        transform.rotation = playerOrientation.rotation;
    }
}
