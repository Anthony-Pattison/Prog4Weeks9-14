using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class searchForPlayerAT : ActionTask {

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			searchAnArea(agent.transform.position + agent.transform.forward * 10, 5);
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		void searchAnArea(Vector3 center, float radius)
		{
			Collider[] hitColliders = Physics.OverlapSphere(center, radius);

			foreach(Collider _collider in hitColliders)
			{
				Vector3 heading =  _collider.transform.position - agent.transform.position;
				RaycastHit hit;
				Debug.DrawRay(agent.transform.position, heading.normalized);
                if (Physics.Raycast(agent.transform.position, heading.normalized, out hit, float.MaxValue))
				{
					if (hit.collider.gameObject.CompareTag("Player"))
						Debug.Log("Found the player");
				}
				else
				{
					Debug.Log("Did not find the player");
				}
			}
		}
	}
}