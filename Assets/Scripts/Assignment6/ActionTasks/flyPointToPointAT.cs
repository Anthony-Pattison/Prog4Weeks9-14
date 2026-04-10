using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
using ParadoxNotion.Serialization.FullSerializer;

namespace NodeCanvas.Tasks.Actions {

	public class flyPointToPointAT : ActionTask {

		public BBParameter<List<Transform>> flyingToLocationsBBP;
		public int spotItteration;
		public float speed;
		public float stoppingDistacne;
		public Transform goToTransform;
		public Vector3 moveTo;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{
			moveToNewLocation();
		}
		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			agent.transform.rotation = goToTransform.rotation;
            agent.transform.position +=  speed * Time.deltaTime * agent.transform.forward;

			if (Vector3.Distance(agent.transform.position, goToTransform.position) < stoppingDistacne)
			{
				spotItteration++;
				moveToNewLocation();
            }
			EndAction();
        }
		void moveToNewLocation()
		{
            if (spotItteration == flyingToLocationsBBP.value.Count)
            {
                spotItteration = 0;
            }
            goToTransform = flyingToLocationsBBP.value[spotItteration].transform;
            moveTo = goToTransform.position;
        }
		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}