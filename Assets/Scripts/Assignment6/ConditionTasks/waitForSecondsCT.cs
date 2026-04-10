using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {
	
	public class waitForSecondsCT : ConditionTask {
		public bool lookAtPlayer = false;
		public BBParameter<Transform> playerTransformBBP;
		public float amountOfSeconds;
		float timer = 0;
		protected override void OnEnable() {
			timer = 0;
			agent.GetComponent<flyingCannonBounce>().growBall();
		}

		protected override bool OnCheck() {
			if(lookAtPlayer)
				agent.transform.LookAt(playerTransformBBP.value);

			if (timer > amountOfSeconds) 
				return true;
			timer += Time.deltaTime;
			return false;
		}
	}
}