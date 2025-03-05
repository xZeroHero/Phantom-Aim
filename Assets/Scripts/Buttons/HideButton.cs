using TMPro;
using UnityEngine;

public class HideButton : MonoBehaviour
{
    public GameManager m_GameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_GameManager.MaxLevelCleared == m_GameManager.CurrentLevel)
        {

        }
    }
}
