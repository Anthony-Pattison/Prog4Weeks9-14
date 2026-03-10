using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

    public class colorChangeAT : ActionTask
    {
        public BBParameter<bool> boolBBP;
        public BBParameter<MeshRenderer> rendererBBP;
        public BBParameter<Transform> lookingForBBP;
        public Color color = Color.white;
        float timer;
        protected override void OnExecute()
        {

            if (boolBBP.value)
                rendererBBP.value.material.color = Random.ColorHSV();

            rendererBBP.value.material.color = color;
        }

        protected override void OnUpdate()
        {
            timer += Time.deltaTime;

            if (timer > 5)
            {
                Vector3 movement = Vector3.zero;
                if (agent.transform.position.x > lookingForBBP.value.position.x)
                {
                    movement.x = -1;
                }
                else
                {
                    movement.x = 1;
                }
                if (agent.transform.position.y > lookingForBBP.value.position.y)
                {
                    movement.y = -1;
                }
                else
                {
                    movement.y = 1;
                }
                agent.transform.position += movement * 3 * Time.deltaTime;

                if (Vector3.Distance(agent.transform.position, lookingForBBP.value.position) > 5.0f)
                {
                    EndAction();
                }
            }

        }

    }
}