using UnityEngine;

public class accManager : MonoBehaviour
{
    public RectTransform top;
    public RectTransform bottom;
    public RectTransform left;
    public RectTransform right;
    public valueObject accuracyValue;
    public float chagneTransform = 45;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float positionOffset = chagneTransform / accuracyValue.value;
        top.localPosition = new Vector3(0, positionOffset, 0);
        bottom.localPosition = new Vector3(0, -positionOffset, 0);
        right.localPosition = new Vector3(positionOffset, 0, 0);
        left.localPosition = new Vector3(-positionOffset, 0, 0);
    }
}
