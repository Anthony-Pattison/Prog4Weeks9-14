using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class PlayerInput : ConditionTask {
        public BBParameter<bool> oncheck;
		
		protected override bool OnCheck() {
			oncheck.value = Input.anyKey;
			return Input.anyKey;
		}
	}
}