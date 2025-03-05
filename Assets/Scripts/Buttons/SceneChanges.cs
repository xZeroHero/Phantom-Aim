using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SceneChanges : MonoBehaviour 
{

    public GameManager m_GameManager;

    public void OpenSkilltreeScene()
    {
        SceneManager.LoadScene("SkillTree");
    }

    public void OpenMainDevScreen()
    {
        SceneManager.LoadScene("Main"); 
    }

    public void OpenLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadNextLevel()
    {
        int NextLevel = m_GameManager.MaxLevelCleared + 1;
        SceneManager.LoadScene("Level" + NextLevel);
    }

    public void InLevelNextLevel()
    {
        m_GameManager.PlayerIsDead = true;
        m_GameManager.LevelCleared();
    }

    public void LoadPreviousLevel()
    {
        int PreviousLevel = m_GameManager.CurrentLevel - 1;
        SceneManager.LoadScene("Level" + PreviousLevel);
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene("Level" + m_GameManager.CurrentLevel);
    }

    public void OpenLevelSelect()
    {

    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
