using UnityEngine;

public class checkPoint : MonoBehaviour
{
    public playerScript player;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        player.playerStart = transform.position;
    }
}
