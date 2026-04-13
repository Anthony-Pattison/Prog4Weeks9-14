using System.Collections;
using UnityEngine;

public class CameraAnimationManager : MonoBehaviour
{
    [SerializeField]
    CameraAnimation[] animations;
    eventCore EventCore;
    private void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        EventCore.EV_playCameraAnimations.AddListener(playAllAnimations);
    }

    [ContextMenu("Play animations")]
    void playAllAnimations()
    {
        StartCoroutine(manageAnimation());
    }

    IEnumerator manageAnimation()
    {
        foreach (var animation in animations)
        {
            yield return animation.camMovement();
        }
        EventCore.EV_finshCameraAnimation.Invoke();
    }
}
