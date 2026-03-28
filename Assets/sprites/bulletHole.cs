using System.Collections;
using UnityEngine;

public class bulletHole : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(fadeOut());
        
    }
    IEnumerator fadeOut()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
