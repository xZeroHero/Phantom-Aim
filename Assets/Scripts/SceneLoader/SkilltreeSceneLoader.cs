using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SkilltreeSceneLoader : MonoBehaviour
{

    public GameManager m_GameManager;
    public UpgradeManager m_UpgradeManager;
    public MovePillarOnDeath m_MovePillarOnDeath;
    public GameObject NextLevelButton;
    public GameObject PreviousLevelButton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadSkillTree();

    }

    public void LoadSkillTree()
    {
        NextLevelButton.SetActive(false);
        PreviousLevelButton.SetActive(false);
        m_GameManager.PlayerIsDead = false;
        m_UpgradeManager.CalculateStats();
        m_MovePillarOnDeath.OpenScene = true;
        m_GameManager.Health = m_GameManager.MaxHealth;
        m_GameManager.ClearedLevel = false;
        if (m_GameManager.MaxLevelCleared == m_GameManager.CurrentLevel && m_GameManager.CurrentLevel <= 11)
        {
            NextLevelButton.SetActive(true);
        }
        if (m_GameManager.CurrentLevel > 1)
        {
            PreviousLevelButton.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
