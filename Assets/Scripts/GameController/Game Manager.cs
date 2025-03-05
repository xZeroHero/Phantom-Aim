using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Arrow Stats
    public float ArrowSpeed;
    public float MaxLifeTime;
    public float RotationSpeed;
    public float ArrowDamage;
    public float ArmorPierce;

    //Player Stats
    public float FireRate;
    public float Health;
    public float MaxHealth;
    public bool PlayerIsDead = false;

    //Enemy Stats
    public float EnemyMaxHealth;
    public float EnemyDamage;
    public float EnemySpeed;
    public float EnemyMinSpawnTime;
    public float EnemyMaxSpawnTime;
    public float EnemyArmor;
    public int EnemiesToSpawn;
    public float SpiritModifier;

    //Global Stats
    public int Spirit;
    public int MaxLevelCleared;
    public int CurrentLevel;
    public bool CurrentLevelCleared;
    public bool ClearedLevel;







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelCleared()
    {
        MaxLevelCleared = CurrentLevel;
        ClearedLevel = true;
    }
}
