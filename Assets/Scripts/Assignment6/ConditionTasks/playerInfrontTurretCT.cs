using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class playerInfrontTurretCT : ConditionTask {
		public BBParameter<Transform> playerTransformBBP;
		public GameObject turretHead;
		public float playAnimationDistance = 15.0f;
		public float shootingDistance = 10.0f;
		Quaternion baseRotation;
		Animator turretHeadAnimator;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			baseRotation = agent.transform.rotation;
			Debug.Log(baseRotation);
            turretHeadAnimator = turretHead.GetComponent<Animator>();

            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			turretHead.transform.rotation = baseRotation;
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			float distance = Vector3.Distance(agent.transform.position, playerTransformBBP.value.position);
			Vector3 direction = (playerTransformBBP.value.position - agent.transform.position).normalized;

			float upAngel = calculateDegAngleFormVector(agent.transform.up);
			float directionAngle = calculateDegAngleFormVector(direction);

			float deltaAngle = Mathf.DeltaAngle(upAngel, directionAngle);
			float sign = Mathf.Sign(deltaAngle);

			if (distance < playAnimationDistance)
			{
				turretHeadAnimator.SetBool("firing", true);
			}
			else
			{
                turretHeadAnimator.SetBool("firing", false);
            }
            if (deltaAngle < 0 && distance < shootingDistance)
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