using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class zigZagMovementAT : ActionTask {
		public AnimationCurve zigzagMovement;
		public BBParameter<Transform> goToLocationBBP;

		public BBParameter<float> speedBBP;

		Vector3 leftSpot;
		Vector3 rightSpot;
        float t = 0;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			leftSpot = agent.transform.position + (Vector3.right * -2);
            rightSpot = agent.transform.position + (Vector3.right * 2);
            return null;
		}


		protected override void OnUpdate() {
			Vector3 playerpos = agent.transform.position;
			Vector3 changeValue = agent.transform.position;
			t += Time.deltaTime;
			
			playerpos = Vector3.Lerp(leftSpot, rightSpot, zigzagMovement.Evaluate(t));
			playerpos.z = changeValue.z;
			agent.transform.position = playerpos;

			if (t >= 1)
			{
				t = 0;
				//EndAction(true);
			}
		}

		
	}
}