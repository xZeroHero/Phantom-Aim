using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{

    public GameManager m_GameManager;
    public GameObject DamageTextPrefab;
    public GameObject SpiritGainPrefab;
    public GameObject SpiritDropPrefab;
    private EnemySpawnerScript EnemySpawnerScript;
    public int Spirit;
    public bool WasKilled;

    private Screenshake cam;
    private Animation EnemyHitAnimation;
    private float m_MaxHealth;
    private float m_Health;
    private float m_Speed;
    private float m_Damage;
    private float m_Weigth;
    private float m_Armor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_MaxHealth = m_GameManager.EnemyMaxHealth;
        m_Health = m_MaxHealth;
        m_Speed = m_GameManager.EnemySpeed;
        m_Damage = m_GameManager.EnemyDamage;
        m_Armor = m_GameManager.EnemyArmor;
        EnemyHitAnimation = GetComponent<Animation>();
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Screenshake>();
        EnemySpawnerScript = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawnerScript>();


    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, new Vector2(0,0),  m_Speed * Time.deltaTime); 
        
        
    }

    public void PlayerHit()
    {
        m_GameManager.Health -= m_Damage;
        cam.StartShaking();
        Destroy(gameObject);

    }

    public void EnemyHit(float Damage)
    {
        m_Health -= Damage;
        string DamageNumber = Damage.ToString();


        

        cam.StartShaking();
        EnemyHitAnimation.Play();
        



        if (m_Health <= 0)
        {
            int CalculatedSpirit = (int)(Spirit * m_GameManager.SpiritModifier);
            Debug.Log("CalculatedSpirit: " + CalculatedSpirit);
            Debug.Log("Spirit: " + Spirit);
            Debug.Log("m_GameManager.SpiritModifier" + m_GameManager.SpiritModifier);

            string SpiritText = CalculatedSpirit.ToString();
            //m_GameManager.Spirit += (int)m_MaxHealth;
            GameObject SpiritDrop = Instantiate(SpiritDropPrefab, gameObject.transform);
            SpiritDrop.GetComponent<SpiritDropScript>().SpiritValue = CalculatedSpirit;
            SpiritDrop.transform.SetParent(null);


            EnemySpawnerScript.EnemiesKilled++;
            WasKilled = true;


            Destroy(gameObject);
           
        }
    }

    public float EnemyPierceModifier(float Pierce)
    {
        float PierceModifier = 0f;

        PierceModifier = Mathf.Clamp01(Pierce / m_Armor);

        return PierceModifier;
    }


}
