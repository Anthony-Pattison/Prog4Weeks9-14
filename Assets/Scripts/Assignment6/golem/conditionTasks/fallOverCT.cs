using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {
	
	public class fallOverCT : ConditionTask {
		public BBParameter<bool> fallOverBBP;
		protected override bool OnCheck() {
			return fallOverBBP.value;
		}
	}
}