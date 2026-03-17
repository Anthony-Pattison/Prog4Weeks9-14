using UnityEngine;

public class plants : MonoBehaviour
{
    [Range(0.0f,100.0f)]
    public float hydration = 0.1f;
    [Range(0.0f,100.0f)]
    public float hunger = 0.1f;

    [SerializeField]
    float decreaseAmount;
    
    void Update()
    {
        hydration -= decreaseAmount * Time.deltaTime;
        hunger -= decreaseAmount * Time.deltaTime;
    }
}
