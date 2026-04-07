using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;


namespace NodeCanvas.Tasks.Actions {

	public class surveyForPlayerAT : ActionTask {
        public BBParameter<Transform> playerTranform;
        NavMeshAgent thisNavAgent;
        Vector3 moveTo;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
            thisNavAgent = agent.GetComponent<NavMeshAgent>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            if(searchAnArea(agent.transform.position, 5))
            {
                EndAction();
            }
            moveTo = randomPosition();
            thisNavAgent.SetDestination(moveTo);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (Vector3.Distance(agent.transform.position, moveTo) < 2)
            {
                EndAction();
            }
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

        Vector3 randomPosition()
        {
            Vector3 agentPosition = agent.transform.position;
            Vector3 randomPosition = 2 * Random.insideUnitSphere + (agentPosition + (agent.transform.forward * 3));
            Vector3 returnValue = Vector3.zero;

            if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, 5, NavMesh.AllAreas))
            {
                returnValue = hit.position;
            }
            else
            {
                returnValue = (agent.transform.forward * 3) + (agent.transform.right);
            }

            return returnValue;
        }

        bool searchAnArea(Vector3 center, float radius)
        {
            Collider[] hitColliders = Physics.OverlapSphere(center, radius);

            foreach (Collider _collider in hitColliders)
            {
                Vector3 heading = _collider.transform.position - agent.transform.position;
                RaycastHit hit;
                Debug.DrawRay(agent.transform.position, heading.normalized);
                if (Physics.Raycast(agent.transform.position, heading.normalized, out hit, float.MaxValue))
                {
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }

            }
            return false;
        }
    }
}