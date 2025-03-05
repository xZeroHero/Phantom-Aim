using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemySpawnerScript : MonoBehaviour
{

    public GameObject Enemy;
    public GameManager m_GameManager;
    public Camera mainCamera;
    public int EnemiesToSpawn;
    public TextMeshProUGUI m_EnemyCounter;
    public SkilltreeSceneLoader m_SkilltreeSceneLoader;
    public GameObject NextLevelButton;
    public int EnemiesKilled;

    private float m_MinSpawnTime;
    private float m_MaxSpawnTime;
    private float m_TimeUntilSpawn;
    private int m_EnemiesSpawned;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_MinSpawnTime = m_GameManager.EnemyMinSpawnTime;
        m_MaxSpawnTime = m_GameManager.EnemyMaxSpawnTime;
        m_EnemiesSpawned = 0;
        EnemiesToSpawn = m_GameManager.EnemiesToSpawn;
        EnemiesKilled = 0;
        //SpawnEnemy();
        SetTimeUntilSpawn();
        //m_EnemyCounter.text = "Enemies Left: " + EnemiesToSpawn;
        NextLevelButton.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {

        m_TimeUntilSpawn -= Time.deltaTime;

            if (m_TimeUntilSpawn < 0)
            {
                //Instantiate(Enemy, transform.position + GetRandomSpawnpoint(), Quaternion.identity);
                SpawnEnemy();
                SetTimeUntilSpawn();
                m_EnemiesSpawned++;
                

            }




        if(EnemiesKilled < EnemiesToSpawn)
        {
            m_EnemyCounter.text = "Enemies Left: " + (EnemiesToSpawn - EnemiesKilled).ToString();

        }

        if (EnemiesKilled >= EnemiesToSpawn || m_GameManager.CurrentLevel <= m_GameManager.MaxLevelCleared)
        {
            m_EnemyCounter.text = "Level Cleared!";
            NextLevelButton.SetActive(true);
            //m_GameManager.PlayerIsDead = true;
            //m_GameManager.LevelCleared();

        }


    }

    private void SetTimeUntilSpawn()
    {
        m_TimeUntilSpawn = Random.Range(m_MinSpawnTime, m_MaxSpawnTime);
    }


    private Vector3 GetRandomSpawnpoint()
    {

        float x = Random.Range(-1.2f, 0.2f);
        float y = Random.Range(-1.2f, 0.2f);
        if (x >= 0) x += 1f;

        if (y >= 0) y += 1f;

        Vector3 randomPoint = new(x, y);

        randomPoint.z = 10f;

        Vector3 worldPoint = Camera.main.ViewportToWorldPoint(randomPoint);

        Debug.Log(worldPoint);
        return worldPoint;
    }




    public void SpawnEnemy()
    {
        Vector2 spawnPosition = GetRandomSpawnPosition();
        Instantiate(Enemy, spawnPosition, Quaternion.identity);
    }

    private Vector2 GetRandomSpawnPosition()
    {
        if (mainCamera == null) mainCamera = Camera.main;

        // Get viewport limits in world space
        float halfHeight = mainCamera.orthographicSize;
        float halfWidth = halfHeight * mainCamera.aspect;

        float x, y;
        int edge = Random.Range(0, 4); // 0: Top, 1: Bottom, 2: Left, 3: Right

        switch (edge)
        {
            case 0: // Top
                x = Random.Range(-halfWidth, halfWidth);
                y = halfHeight + 0.1f; // Spawn slightly outside
                break;
            case 1: // Bottom
                x = Random.Range(-halfWidth, halfWidth);
                y = -halfHeight - 0.1f;
                break;
            case 2: // Left
                x = -halfWidth - 0.1f;
                y = Random.Range(-halfHeight, halfHeight);
                break;
            case 3: // Right
                x = halfWidth + 0.1f;
                y = Random.Range(-halfHeight, halfHeight);
                break;
            default:
                x = y = 0;
                break;
        }

        return new Vector2(x, y);
    }

}
