using System.Collections;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{

    public GameObject DeathPanelPrefab;
    public float Delay;
    public bool Dead;

    private float ElapsedTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Dead)
        {
            StartDeathPanel();
            Dead = false;
        }
    }

    public void StartDeathPanel()
    {
        StartCoroutine(CreateDeathPanel());
    }
    IEnumerator CreateDeathPanel()
    {

        ElapsedTime += Time.deltaTime;
        Debug.Log(ElapsedTime);
        if (ElapsedTime > Delay)
        {
            Debug.Log("DeathPanel Started");
            GameObject DeathPanel = Instantiate(DeathPanelPrefab, new Vector3(0f, 0f, 40f), Quaternion.identity);
            //DeathPanel.transform.parent = gameObject.transform;
            DeathPanel.transform.SetParent(transform, false);

            yield return null;
        }
    }
}
