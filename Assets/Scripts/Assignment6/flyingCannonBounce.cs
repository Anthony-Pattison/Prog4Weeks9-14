using System.Collections;
using UnityEngine;

public class flyingCannonBounce : MonoBehaviour
{
    public AnimationCurve bounceCurve;
    public GameObject bulletBall;
    public float waitTime = 0.1f;
    float time;
    Vector3 top;
    Vector3 bottom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        top = transform.position + (Vector3.up);
        bottom = transform.position - (Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.Lerp(top, bottom, bounceCurve.Evaluate(time));
        Vector3 playerPos = transform.position;
        
        playerPos.y = movement.y;

        transform.position = playerPos;

        time += 0.25f * Time.deltaTime;
        if(time>=1)
            time = 0;
    }

    public void growBall()
    {
        StartCoroutine(growBallCorutine());
    }

    IEnumerator growBallCorutine()
    {
        float amount = 0;
        bulletBall.transform.localScale = Vector3.zero;
        bulletBall.SetActive(true);

        while (amount < 1)
        {
            amount += 0.5f * Time.deltaTime;
            bulletBall.transform.localScale = new Vector3(amount, amount, amount);
            yield return new WaitForSeconds(waitTime);
        }
        bulletBall.SetActive(false);
    }
}
