using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class isPlayerLookingCT : ConditionTask {
		public BBParameter<Transform> playerTransformBBP;
		public BBParameter<bool> playerLookingBBP;
		public float noticePlayerDistance;
		

		protected override bool OnCheck() {
			if (playerLookingBBP.value)
			{
                return true;
            }
			return false;
        }
	}
}