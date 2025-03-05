using System.Collections;
using UnityEngine;

public class Screenshake : MonoBehaviour
{

    public static bool start = false;
    public AnimationCurve Curve;
    public float duration = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            start = false;
            StartCoroutine(Shaking());

        }
    }

    public void StartShaking()
    {
        gameObject.SetActive(true);
        StartCoroutine(Shaking());
    }


    IEnumerator Shaking()
    {

        Vector3 StartingPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float Strength = (Curve.Evaluate(elapsedTime / duration)/30);
            transform.position = StartingPosition + Random.insideUnitSphere * Strength;
            yield return null;
        }

        transform.position = StartingPosition;
        
    }

}
