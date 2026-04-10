using UnityEngine;

public class flyingCannonBounce : MonoBehaviour
{
    public AnimationCurve bounceCurve;
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
}
