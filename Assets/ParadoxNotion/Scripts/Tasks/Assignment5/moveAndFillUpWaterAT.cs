using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{

    public class moveAndFillUpWaterAT : ActionTask
    {
        public BBParameter<Transform> waterFillStationBBP;
        public BBParameter<float> stoppingDistanceBBP;
        gardenerManager gardenerManager;

        protected override string OnInit()
        {
            gardenerManager = agent.GetComponent<gardenerManager>();

            return null;
        }
        protected override void OnExecute()
        {
            agent.GetComponent<NavMeshAgent>().SetDestination(waterFillStationBBP.value.position);

        }
        protected override void OnUpdate()
        {
            Debug.Log(Vector3.Distance(agent.transform.position, waterFillStationBBP.value.position));
            if (Vector3.Distance(agent.transform.position, waterFillStationBBP.value.position) < stoppingDistanceBBP.value)
            {
                gardenerManager.wateringCanWater = 100;
                EndAction();

            }
        }

    }
}