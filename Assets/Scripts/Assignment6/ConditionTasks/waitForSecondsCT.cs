using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class waitForSecondsCT : ConditionTask {
		public float amountOfSeconds;
		float timer = 0;
		protected override void OnEnable() {
			timer = 0;
		}

		protected override bool OnCheck() {
			if (timer > amountOfSeconds) 
				return true;
			timer += Time.deltaTime;
			return false;
		}
	}
}