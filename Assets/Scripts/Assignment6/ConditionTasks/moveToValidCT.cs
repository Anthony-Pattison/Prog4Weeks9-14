using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Conditions {

	public class moveToValidCT : ConditionTask {

		public BBParameter<Vector3> moveToBBP;
		NavMeshAgent thisNavAgent;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			thisNavAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
            NavMeshPath path = new NavMeshPath();

            if (moveToBBP.value != Vector3.zero)
			{
                return true;
            }
			return false;
        }
	}
}