using NodeCanvas.Framework;
using UnityEngine;

public class knockOverGolem : MonoBehaviour
{
    public Blackboard golemBlackboard;
    public void setGolemValue()
    {
        golemBlackboard.SetVariableValue("fallOver", true);
    }
}
