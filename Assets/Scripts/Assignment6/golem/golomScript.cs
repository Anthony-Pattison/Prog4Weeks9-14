using NodeCanvas.StateMachines;
using UnityEngine;

public class golomScript : MonoBehaviour
{
    public bool doneAttacking;
    public bool doneDaze;
    eventCore EventCore;
    public FSMOwner FSMOwner;
    public CameraAnimation CameraAnimation;
    private void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        EventCore.EV_finshCameraAnimation.AddListener(unPauseThis);
    }

    public void golumDefeated()
    {
        CameraAnimation.startCameraMovement();
    } 

    void unPauseThis()
    {
        FSMOwner.enabled = true;
    }
    public void onAttackStart()
    {
        doneAttacking = false;
    }

    public void onAttackFinish()
    {
        doneAttacking = true;
    }
    
    public void onDazeStart()
    {
        doneDaze = false;
    }

    public void onDazeFinish()
    {
        doneDaze = true;
    }
}
