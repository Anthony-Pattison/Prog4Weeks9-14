using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SeekAT : ActionTask {

		public BBParameter<Transform> targetTransformBBP;
		public BBParameter<Vector3> moveDirectionBBP;
		[MinValue(0.0f)] public float weight;

		protected override void OnUpdate() {
			// change the movement to seek towards the target position
			moveDirectionBBP.value += (targetTransformBBP.value.position - agent.transform.position).normalized * weight;
		}

		
	}
}