using UnityEngine;

public class StopAnimation : MonoBehaviour
{

    public Animation Animation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopsAnimation()
    {
        Animation.Stop();
    }
}
