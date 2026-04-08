using UnityEngine;

public class targetScript : MonoBehaviour
{
    public GameObject unlockAbleDoor;
    public Material unlockMaterial;
    [SerializeField] string animationTrigger;
    eventCore EventCore;
    public GameObject targetModel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // getting objects
        targetModel = transform.GetChild(0).gameObject;
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        //adding listener for the target getting shot
        EventCore.EV_targetShot.AddListener(openLockedDoor);
    }
    // if the target that got shot is this one
    void openLockedDoor(string targetName)
    {
        if (targetName != this.gameObject.name)
            return;
        MeshRenderer mr = targetModel.GetComponent<MeshRenderer>();
        print(mr.materials[1].name);
        mr.materials[1].color = Color.red;
        unlockAbleDoor.GetComponent<Animator>().SetTrigger(animationTrigger);
    }
}
