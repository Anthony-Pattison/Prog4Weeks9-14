using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


namespace NodeCanvas.Tasks.Actions
{

    public class shootThePlayerAT : ActionTask
    {
        public BBParameter<Transform> playerTransformBBP;
        public float fireDistance;
        public float damage = 5.0f;
        public AudioClip gunFire;
        public bool dontplaySound = false;
        public bool dontLookAtPlayer = false;
        eventCore EventCore;
        AudioSource AudioSource;

        Coroutine shooting;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
            AudioSource = GameObject.Find("audioManager").GetComponent<AudioSource>();

            return null;
        }
        protected override void OnExecute()
        {
            RaycastHit hit;
            if(!dontLookAtPlayer) 
                agent.transform.LookAt(playerTransformBBP.value);

            Debug.DrawRay(agent.transform.position, (playerTransformBBP.value.position - agent.transform.position).normalized * fireDistance);
            if (Physics.Raycast(agent.transform.position, agent.transform.forward, out hit, fireDistance))
            {
                Debug.Log(hit.collider.name);
                if(!dontplaySound)
                    AudioSource.Play();
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    EventCore.playerDamage.Invoke(damage);
                }
            }
            if (dontLookAtPlayer)
            {
                shooting = StartCoroutine(turretShooting());
            }
        }

       IEnumerator turretShooting()
        {
            while (true) {
                RaycastHit hit;

                if (Physics.Raycast(agent.transform.position, (playerTransformBBP.value.position - agent.transform.position).normalized, out hit, fireDistance))
                {
                    Debug.Log(hit.collider.name);
                    if (!dontplaySound)
                        AudioSource.Play();
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        EventCore.playerDamage.Invoke(damage);
                    }
                }

                Vector3 direction = (playerTransformBBP.value.position - agent.transform.position).normalized;

                float upAngel = calculateDegAngleFormVector(agent.transform.up);
                float directionAngle = calculateDegAngleFormVector(direction);

                float deltaAngle = Mathf.DeltaAngle(upAngel, directionAngle);
                float sign = Mathf.Sign(deltaAngle);

                if (deltaAngle < 0)
                {
                    EndAction(true);
                }
                yield return new WaitForSeconds(1f);
            }
        }

        protected override void OnStop()
        {
            if (shooting != null)
            {
                StopCoroutine(shooting);
            }
        }

        private float calculateDegAngleFormVector(Vector3 position)
        {
            return Mathf.Atan2(position.x, position.z) * Mathf.Rad2Deg;
        }
    }
}