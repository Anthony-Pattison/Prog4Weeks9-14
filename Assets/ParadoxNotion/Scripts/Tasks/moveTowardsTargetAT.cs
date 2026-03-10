using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class moveTowardsTargetAT : ActionTask {
		public BBParameter<float> speedBBP;
        public BBParameter<MeshRenderer> rendererBBP;
        public Color color = Color.white;
        Vector3 locationRight;
        Vector3 locationLeft;
		Vector3 movingTowards;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			locationLeft = agent.transform.position - Vector3.right * 2;
			locationRight = agent.transform.position + Vector3.right * 2;
			movingTowards = locationRight;
            return null;
		}

     
		protected override void OnExecute()
		{
            rendererBBP.value.material.color = color;
            agent.transform.position += Vector3.right * speedBBP.value * Time.deltaTime;
            
			if (Vector3.Distance(agent.transform.position, movingTowards) < 0.1f)
			{
                speedBBP.value = speedBBP.value * -1;
				if (movingTowards == locationRight)
				{
                    movingTowards = locationLeft;
				}
				else
				{
                    movingTowards = locationRight;
                }
            }
            EndAction(true);

        }
    }
}