using UnityEngine;

public class golomScript : MonoBehaviour
{
    public bool doneAttacking;
    public bool doneDaze;
    
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
