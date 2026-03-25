using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class searchForPlayerCT : ConditionTask {

        public BBParameter<Transform> playerLastTransformBBP;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}
        bool searchAnArea(Vector3 center, float radius)
        {
            Collider[] hitColliders = Physics.OverlapSphere(center, radius);

            foreach (Collider _collider in hitColliders)
            {
                Vector3 heading = _collider.transform.position - agent.transform.position;
                RaycastHit hit;
                Debug.DrawRay(agent.transform.position, heading.normalized);
                if (Physics.Raycast(agent.transform.position, heading.normalized, out hit, float.MaxValue))
                {
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        playerLastTransformBBP.value = hit.collider.gameObject.transform;
                        Debug.Log("Found the player");
                        return true;
                    }
                }
                else
                {
                    Debug.Log("Did not find the player");
                    playerLastTransformBBP.value.position = Vector3.zero;
                    return true;
                }

            }
            return false;
        }
        //Called once per frame while the condition is active.
        //Return whether the condition is success or failure.
        protected override bool OnCheck() {
            return searchAnArea(agent.transform.position + agent.transform.forward * 10, 5);
		}
	}
}