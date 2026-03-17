using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class moveToAndTendAT : ActionTask {

		public BBParameter<GameObject> plantToTend;
		public BBParameter<float> speedBBP;
		public BBParameter<float> stoppingDistanceBBP;

		Transform destination;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			if (plantToTend.value != null)
			{
				destination = plantToTend.value.transform;
				agent.GetComponent<NavMeshAgent>().SetDestination(destination.position);
				
			}
			else
			{
                Debug.Log("All plants have full waters");
                EndAction();
            }
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			if (Vector3.Distance(agent.transform.position, destination.position) < stoppingDistanceBBP.value)
			{
				if (agent.GetComponent<gardenerManager>().wateringCanWater <= 0 || plantToTend.value.GetComponent<plants>().hydration == 100)
				{
					EndAction();
				}
				agent.GetComponent<gardenerManager>().wateringCanWater -= 2;
				plantToTend.value.GetComponent<plants>().hydration += 2;
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}