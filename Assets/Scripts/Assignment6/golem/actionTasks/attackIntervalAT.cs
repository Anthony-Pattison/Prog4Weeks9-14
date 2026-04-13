using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class attackIntervalAT : ActionTask {

		public BBParameter<float> attackIntervalMaxBBP;
		public BBParameter<float> attackIntervalMinBBP;
		public BBParameter<float> attackIntervalTimeBBP;
		public BBParameter<bool> attackBBP;
		float timeNeeded;
		Coroutine waitTime;
		bool isPlaying;
        //Called once per frame while the action is active.
        protected override void OnExecute()
        {
			attackBBP.value = false;
            attackIntervalTimeBBP.value = 0;
            timeNeeded = Random.Range(attackIntervalMinBBP.value, attackIntervalMaxBBP.value);
        }
        protected override void OnUpdate() {

			attackIntervalTimeBBP.value += Time.deltaTime;

			if (timeNeeded <= attackIntervalTimeBBP.value)
			{
				attackBBP.value = true;
                EndAction();
            }

        }

		IEnumerator waitToEnd()
		{
			isPlaying = true;
			yield return new WaitForSeconds(.5f);
		}
        protected override void OnStop()
		{
			isPlaying = false;
		}

    }
}