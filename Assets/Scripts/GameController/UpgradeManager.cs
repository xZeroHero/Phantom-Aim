using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameManager m_GameManager;
    

  
    //Player Stats

    //Arrow Stats
    public float BaseArrowSpeed;
    public float ArrowSpeedModifier;
    public int ArrowSpeedUpgrades;
    public int ArrowSpeedUpgradeLimit;
    //private float m_ArrowSpeed;

    public float BaseMaxLifeTime;
    public float MaxLifeTimeModifier;
    public int MaxLifeTimeUpgrades;
    public int MaxLifeTimeUpgradeLimit;
    //private float m_MaxLifeTime;

    public float BaseRotationSpeed;
    public float RotationSpeedModifier;
    public int RotationSpeedUpgrades;
    public int RotationSpeedUpgradeLimit;
    //private float RotationSpeed;

    public float BaseArrowDamage;
    public float ArrowDamageModifier;
    public int ArrowDamageUpgrades;
    public int ArrowDamageUpgradeLimit;

    public float BaseArmorPierce;
    public float ArmorPierceModifier;
    public int ArmorPierceUpgrades;
    public int ArmorPierceUpgradeLimit;

    //Player Stats
    public float BaseFireRate;
    public float FireRateModifier;
    public int FireRateUpgrades;
    public int FireRateUpgradeLimit;

    public float BaseMaxHealth;
    public float MaxHealthModifier;
    public int MaxHealthUpgrades;
    public int MaxHealthUpgradeLimit;

    public float BaseSpiritModifier;
    public float SpiritModifier;
    public int SpiritUpgrades;
    public int SpiritUpgradeLimit;
    public float LevelSpiritModifier;



    //Global Stats
    public int Spirit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //m_GameManager.ArrowSpeed = BaseArrowSpeed;
        //m_GameManager.MaxLifeTime = BaseMaxLifeTime;
        //m_GameManager.RotationSpeed = BaseRotationSpeed;
        //m_GameManager.ArrowDamage = BaseArrowDamage;
        //m_GameManager.ArmorPierce = BaseArmorPierce;
        //m_GameManager.FireRate = BaseFireRate;
        //m_GameManager.MaxHealth = BaseMaxHealth;
        Spirit = m_GameManager.Spirit;
        CalculateStats();

    }

    // Update is called once per frame
    void Update()
    {
             
    }

    public void ResetToDefault()
    {
        m_GameManager.ArrowSpeed = BaseArrowSpeed;
        m_GameManager.MaxLifeTime = BaseMaxLifeTime;
        m_GameManager.RotationSpeed = BaseRotationSpeed;
        m_GameManager.ArrowDamage = BaseArrowDamage;
        m_GameManager.ArmorPierce = BaseArmorPierce;
        m_GameManager.FireRate = BaseFireRate;
        m_GameManager.MaxHealth = BaseMaxHealth;
        m_GameManager.SpiritModifier = BaseSpiritModifier;

        ArrowSpeedUpgrades = 0;
        MaxLifeTimeUpgrades = 0;
        RotationSpeedUpgrades = 0;
        ArrowDamageUpgrades = 0;
        ArmorPierceUpgrades = 0;
        FireRateUpgrades = 0;
        MaxHealthUpgrades = 0;
        SpiritUpgrades = 0;

    }

    public void CalculateStats()
    {

        m_GameManager.ArrowSpeed = BaseArrowSpeed + (ArrowSpeedModifier * ArrowSpeedUpgrades);
        m_GameManager.MaxLifeTime = BaseMaxLifeTime + (MaxLifeTimeModifier * MaxLifeTimeUpgrades);
        m_GameManager.RotationSpeed = BaseRotationSpeed + (RotationSpeedModifier * RotationSpeedUpgrades);
        m_GameManager.ArrowDamage = BaseArrowDamage + (ArrowDamageModifier * ArrowDamageUpgrades);
        m_GameManager.ArmorPierce = BaseArmorPierce + (ArmorPierceModifier * ArmorPierceUpgrades);
        m_GameManager.FireRate = BaseFireRate - (FireRateModifier * FireRateUpgrades);
        m_GameManager.MaxHealth = BaseMaxHealth + (MaxHealthModifier * MaxHealthUpgrades);
        m_GameManager.SpiritModifier = BaseSpiritModifier + ((float)((m_GameManager.CurrentLevel-1) * 0.25) + (SpiritModifier * SpiritUpgrades));


    }



}
