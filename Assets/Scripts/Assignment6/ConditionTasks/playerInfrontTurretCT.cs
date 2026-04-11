using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class playerInfrontTurretCT : ConditionTask {
		public BBParameter<Transform> playerTransformBBP;
		public GameObject turretHead;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			turretHead.transform.eulerAngles = new Vector3(0, -270, 0);
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			Debug.DrawLine(agent.transform.position, playerTransformBBP.value.position);
			Debug.DrawLine(agent.transform.position, Vector3.zero);
			Debug.DrawLine(playerTransformBBP.value.position, Vector3.zero);

			Vector3 direction = (playerTransformBBP.value.position - agent.transform.position).normalized;

			float upAngel = calculateDegAngleFormVector(agent.transform.up);
			float directionAngle = calculateDegAngleFormVector(direction);

			float deltaAngle = Mathf.DeltaAngle(upAngel, directionAngle);
			float sign = Mathf.Sign(deltaAngle);

			if (deltaAngle > 0)
			{
				Debug.Log("Infront of me");
				return true;
			}

            return false;
		}

		private float calculateDegAngleFormVector(Vector3 position)
		{
			return Mathf.Atan2(position.x, position.z) * Mathf.Rad2Deg;
		}
    }
}