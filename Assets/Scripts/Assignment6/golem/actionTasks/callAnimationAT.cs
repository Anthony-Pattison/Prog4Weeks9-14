using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class callAnimationAT : ActionTask {

		public string triggerName;
		public Animator animator;
		
		protected override void OnExecute() {
			animator.SetTrigger(triggerName);
		}

	}
}