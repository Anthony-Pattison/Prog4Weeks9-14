using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class detectObjectCT : ConditionTask {

		public BBParameter<Transform> lookingForBBP;
		protected override bool OnCheck() {
			
			return Vector3.Distance(agent.transform.position, lookingForBBP.value.position) < 3;
		}
	}
}