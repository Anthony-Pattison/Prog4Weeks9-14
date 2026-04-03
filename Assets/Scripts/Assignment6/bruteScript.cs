using NodeCanvas.Framework;
using UnityEngine;

public class bruteScript : MonoBehaviour
{
    public playerWeapon plWeapon;
    public Blackboard bruteBlackboard;

    public float runValue;
    public float attackValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bruteBlackboard = GetComponent<Blackboard>();

    }

    // Update is called once per frame
    void Update()
    {
        if (plWeapon.lookingAt == this.gameObject)
        {
            bruteBlackboard.SetVariableValue("playerLooking", true);
            runValue += Time.deltaTime;
            attackValue -= Time.deltaTime;
        }
        else
        {
            runValue -= Time.deltaTime;
            attackValue += Time.deltaTime;
            bruteBlackboard.SetVariableValue("playerLooking", false);
        }
        runValue = Mathf.Clamp(runValue, 0.0f, 1.0f);
        attackValue = Mathf.Clamp(attackValue, 0.0f, 1.0f);

        bruteBlackboard.SetVariableValue("pri1", runValue);
        bruteBlackboard.SetVariableValue("pri2", attackValue);

    }
}
