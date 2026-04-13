using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class rotateTowardsPlayer : ActionTask {
		public BBParameter<Transform> playerTransformBBP;

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Vector3 agentRotation = playerTransformBBP.value.transform.position;
            agent.transform.LookAt(agentRotation);
		}
	}
}