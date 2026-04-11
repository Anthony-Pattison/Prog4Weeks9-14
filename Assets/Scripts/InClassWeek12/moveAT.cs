using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class moveAT : ActionTask {
		
		public BBParameter<Vector3> moveDirectionBBP;
		public BBParameter<float> moveSpeedBBP;
		public BBParameter<float> turnSpeedBBP;


		protected override void OnUpdate() {

			Vector3 planer = new(moveDirectionBBP.value.x, 0, moveDirectionBBP.value.z);

			// get the look rotation for the desired location
			Quaternion desiredRotation = Quaternion.LookRotation(planer);
			Quaternion currentRotation = agent.transform.rotation;

			// point forward vector towards the destination
            agent.transform.rotation = Quaternion.RotateTowards(currentRotation, desiredRotation, turnSpeedBBP.value * Time.deltaTime);

			// apply the transform
			agent.transform.position += moveSpeedBBP.value * Time.deltaTime * agent.transform.forward;

			moveDirectionBBP.value = Vector3.zero;
		}

	}
}