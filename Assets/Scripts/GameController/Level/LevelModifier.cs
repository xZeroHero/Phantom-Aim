using UnityEngine;

public class LevelModifier : MonoBehaviour
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


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
