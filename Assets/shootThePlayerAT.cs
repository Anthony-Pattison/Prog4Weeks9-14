using NodeCanvas.Framework;
using ParadoxNotion.Design;
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
        eventCore EventCore;
        AudioSource AudioSource;
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
            EndAction(true);
        }

    }
}