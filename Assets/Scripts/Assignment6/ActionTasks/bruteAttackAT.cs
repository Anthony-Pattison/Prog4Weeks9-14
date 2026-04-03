using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class bruteAttackAT : ActionTask {
		public BBParameter<Transform> playerTransformBBP;
		eventCore Eventcore;
		public float damageAmount = 5.0f;
		public float attackDistance = 2.0f;
		public Animator zomDogAnimator;

		protected override string OnInit() {
			Eventcore = GameObject.Find("EventCore").GetComponent<eventCore>();
			return null;
		}

		protected override void OnExecute() {
			if (Vector3.Distance(agent.transform.position, playerTransformBBP.value.position) < attackDistance)
			{
				Eventcore.playerDamage.Invoke(damageAmount);
			}
		}

	}
}