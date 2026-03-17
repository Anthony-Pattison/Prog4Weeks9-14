using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {
	
	public class checkWaterCT : ConditionTask {
		public BBParameter<float> minWaterBBP;
		public bool checkGreaterThan = true;
		gardenerManager gardenerManager;
	
		protected override string OnInit(){
			gardenerManager = agent.GetComponent<gardenerManager>();
			return null;
		}
		
		protected override bool OnCheck() {
			// if the gardener has enough water
			if (checkGreaterThan)
			{
				if (gardenerManager.wateringCanWater >= minWaterBBP.value)
				{
					return true;
				}
				return false;
			}
			// if the gardener doesnt have enough water
            if (!checkGreaterThan)
            {
                if (gardenerManager.wateringCanWater <= minWaterBBP.value)
                {
                    return true;
                }
                return false;
            }

			return false;
        }
	}
}