using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

    public class AvoidAT : ActionTask
    {

        public BBParameter<Vector3> moveDirectionBBP;
        public LayerMask obstecalsLayer;
        public float closeRadius, nearRadius, farRadius;
        public float closeWeight, nearWeight, farWeight;

        protected override void OnUpdate()
        {

            Collider[] obsicals = Physics.OverlapSphere(agent.transform.position, farRadius, obstecalsLayer);
            // loop through all colliders
            foreach (Collider obsical in obsicals)
            {
                float weight = 0;

                float distanceToObstical = Vector3.Distance(agent.transform.position, obsical.transform.position);

                if (distanceToObstical < closeRadius)
                    weight = closeWeight;

                else if (distanceToObstical < nearRadius)
                    weight = nearWeight;

                else
                    weight = farWeight;
                // apply a weight to the movement and rotation to the agent to stop it form running into other colliders in scene
                Vector3 directionFormObstical = (agent.transform.position - obsical.transform.position).normalized;
                moveDirectionBBP.value += directionFormObstical * weight;
            }
        }


    }
}