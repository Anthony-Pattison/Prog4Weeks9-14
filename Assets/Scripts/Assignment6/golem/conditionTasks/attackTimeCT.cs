using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class attackTimeCT : ConditionTask {

		public BBParameter<bool> attackPlayerBBP;

		protected override bool OnCheck() {
			return attackPlayerBBP.value;
		}
	}
}