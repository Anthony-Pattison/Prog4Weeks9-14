using NodeCanvas.Tasks.Actions;
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
    }
    private void Update()
    {
        checkAllTargets();
    }
    void checkAllTargets()
    {
        targetsGotten = 0;
        for (int i = 0; i < targetNeeded.Length; i++)
        {

            if (!targetNeeded[i].hasBeenShot)
                return;
            targetsGotten++;
            print($"got {targetsGotten} needed {targetNeeded.Length}");

            if (targetsGotten == targetNeeded.Length)
            {
                unlockAbleDoor.GetComponent<Animator>().SetTrigger(animationTrigger);
                if (GetComponent<knockOverGolem>() != null)
                {
                    GetComponent<knockOverGolem>().setGolemValue();
                    this.enabled = false;
                }
                else
                {
                    this.enabled = false;
                }
            }

        }

    }
}
