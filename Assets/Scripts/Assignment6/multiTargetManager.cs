using UnityEngine;
using UnityEngine.UI;

public class multiTargetManager : MonoBehaviour
{
    eventCore EventCore;
    public targetScript[] targetNeeded;
    [SerializeField] string animationTrigger = "unlockDoor";
    public GameObject unlockAbleDoor;
    int targetsGotten = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        EventCore.EV_targetShot.AddListener(checkAllTargets);
    }

    void checkAllTargets(string targetName)
    {
        for(int i = 0; i < targetNeeded.Length; i++)
        {
            if (targetName == targetNeeded[i].name)
            {
                if (!targetNeeded[i].hasBeenShot)
                    targetsGotten++;
                print($"got {targetsGotten} needed {targetNeeded.Length}");
                if (targetsGotten == targetNeeded.Length)
                {
                    unlockAbleDoor.GetComponent<Animator>().SetTrigger(animationTrigger);
                    this.enabled = false;
                }
                continue;
            }
        }

    } 
}
