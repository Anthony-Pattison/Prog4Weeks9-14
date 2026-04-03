using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class shootThePlayerAT : ActionTask {
		public BBParameter<Transform> playerTransformBBP;
		public float fireDistance;
		eventCore EventCore;
		AudioSource AudioSource;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
			AudioSource = GameObject.Find("audioManager").GetComponent<AudioSource>();

            return null;
		}
		protected override void OnExecute() {
			RaycastHit hit;
			if (Physics.Raycast(agent.transform.position, (playerTransformBBP.value.position - agent.transform.position), out hit, fireDistance))
			{
				AudioSource.Play();
				if (hit.collider.gameObject.CompareTag("Player"))
				{
					EventCore.playerDamage.Invoke(5.0f);
				}
			}
			EndAction(true);
		}

	}
}