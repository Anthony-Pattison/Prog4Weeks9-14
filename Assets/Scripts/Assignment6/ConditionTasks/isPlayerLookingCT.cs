using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class isPlayerLookingCT : ConditionTask {
		public BBParameter<GameObject> playerBBP;
		public BBParameter<bool> playerLookingBBP;
		public float noticePlayerDistance;
		Transform playerTransform;
		
		protected override string OnInit(){
			playerTransform = playerBBP.value.transform;
			return null;
		}

		protected override bool OnCheck() {
			if (playerLookingBBP.value)
			{
                return true;
            }
			return false;
        }
	}
}