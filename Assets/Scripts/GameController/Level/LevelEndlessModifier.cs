using UnityEngine;

public class LevelEndlessModifier : MonoBehaviour
{

    public GameManager m_GameManager;
    public UpgradeManager m_UpgradeManager;
    public float EnemyHealthModifier;
    public float EnemyDamageModifier;
    public float EnemySpeedModifier;
    public float EnemyMinSpawnRateModifier;
    public float EnemyMaxSpawnRateModifier;
    public int EnemiesToSpawn;
    public float SpiritModifier;
    public bool IsCleared;
    public int CurrentLevel;


    public float Incremented_EnemyMaxSpawnRateModifier;
    public float elapsedTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_GameManager.EnemyMaxHealth = EnemyHealthModifier;
        m_GameManager.EnemyDamage = EnemyDamageModifier;
        m_GameManager.EnemySpeed = EnemySpeedModifier;
        m_GameManager.EnemyMinSpawnTime = EnemyMinSpawnRateModifier;
        m_GameManager.EnemyMaxSpawnTime = EnemyMaxSpawnRateModifier;
        m_GameManager.EnemiesToSpawn = EnemiesToSpawn;
        m_GameManager.Health = m_GameManager.MaxHealth;
        //m_GameManager.SpiritModifier = SpiritModifier;
        m_GameManager.PlayerIsDead = false;
        m_GameManager.CurrentLevel = CurrentLevel;
        //m_UpgradeManager.LevelSpiritModifier = SpiritModifier;
        Incremented_EnemyMaxSpawnRateModifier = EnemyMaxSpawnRateModifier;


    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > 5.0f)
        {
            IncrementStats();
            elapsedTime = 0.0f;
        }


    }

    public void IncrementStats()
    {
        if (EnemyMaxSpawnRateModifier > 0.1f)
        {
            Incremented_EnemyMaxSpawnRateModifier -= 0.1f;
            m_GameManager.EnemyMaxSpawnTime = Incremented_EnemyMaxSpawnRateModifier;

        }

    }

    public void UpdateStats()
    {
        {
            m_GameManager.EnemyMaxHealth = EnemyHealthModifier;
            m_GameManager.EnemyDamage = EnemyDamageModifier;
            m_GameManager.EnemySpeed = EnemySpeedModifier;
            m_GameManager.EnemyMinSpawnTime = EnemyMinSpawnRateModifier;
            m_GameManager.EnemyMaxSpawnTime = EnemyMaxSpawnRateModifier;
            m_GameManager.EnemiesToSpawn = EnemiesToSpawn;
            m_GameManager.Health = m_GameManager.MaxHealth;
        }
    }
}
