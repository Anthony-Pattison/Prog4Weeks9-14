using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions
{

    public class moveToAT : ActionTask
    {
        public BBParameter<Vector3> moveTo;
        public float stoppingDistance = 4;
        public BBParameter<Transform> playerTransform;
        public bool moveToPlayer;
        public bool lookAt;

        Vector3 leftOfPlayer;
        Vector3 rightOfPlayer;
        Vector3 playerLocation;

        NavMeshAgent thisNavAgent;

        void calculateAttackPlayerMovement()
        {
            playerLocation = playerTransform.value.position;
            leftOfPlayer = playerLocation - Vector3.left * 2;
            rightOfPlayer = playerLocation + Vector3.right * 2;
        }

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            thisNavAgent = agent.GetComponent<NavMeshAgent>();
            return null;
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {
            if (moveToPlayer)
            {
                Vector3[] possibleLocation = new Vector3[]{leftOfPlayer, rightOfPlayer, playerLocation};
                calculateAttackPlayerMovement();
                for (int i = 0; i < 2; i++)
                {
                    if (thisNavAgent.SetDestination(possibleLocation[i]))
                    {
                        moveTo.value = possibleLocation[i];
                    }
                }
            }
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {
            thisNavAgent.SetDestination(moveTo.value);
            if (lookAt)
            {
                agent.transform.LookAt(playerTransform.value.position);
            }
            if (Vector3.Distance(agent.transform.position, moveTo.value) < stoppingDistance)
            {
                EndAction();
            }
        }

        //Called when the task is disabled.
        protected override void OnStop()
        {

        }

        //Called when the task is paused.
        protected override void OnPause()
        {

        }
    }
}