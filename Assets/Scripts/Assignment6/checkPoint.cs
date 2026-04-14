using UnityEngine;

public class checkPoint : MonoBehaviour
{
    public playerScript player;
    public Material activeCheckPoint;
    public Material inActiveCheckPoint;
    eventCore EventCore;

    private void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        EventCore.EV_playGotCheckPoint.AddListener(setMaterial);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        player.playerStart = transform.position;
        GetComponent<AudioSource>().Play();
        EventCore.EV_playGotCheckPoint.Invoke();
        GetComponent<MeshRenderer>().material = activeCheckPoint;
    }

    void setMaterial()
    {
        GetComponent<MeshRenderer>().material = inActiveCheckPoint;
    }
}
