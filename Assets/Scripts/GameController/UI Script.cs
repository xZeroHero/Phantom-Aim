using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{

    public GameManager m_GameManager;

    //UI Elements
    public TextMeshProUGUI m_Text;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Text.text = m_GameManager.Spirit.ToString();
    }
}
