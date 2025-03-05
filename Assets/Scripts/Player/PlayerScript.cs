using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public GameManager m_GameManager;
    public GameObject arrowPrefab;
    public GameObject DirectionPointerPrefab;
    public Image progressBar;
    public Image ArrowDurationBar;
    public Image HealthBar;
    public GameObject DeathAnimationPrefab;
    public GameObject DeathPanelPrefab;
    public GameObject Canvas;

    public static bool ArrowActive;
    private float Health;



    private Vector2 m_direction;
    private Vector2 m_spawnPosition;
    private float m_rotationAngle;
    private bool m_DirectionPointerActive;

    private float FireRate;
    private float MaxHealth;
    
    private float TimePassed = 0;



    //private float arrowSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        FireRate = m_GameManager.FireRate;
        MaxHealth = m_GameManager.MaxHealth;
        Health = m_GameManager.Health;
        ArrowActive = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (!ArrowActive)
        {
            TimePassed += Time.deltaTime;
            if (!m_DirectionPointerActive)
            {
                NewSpawnParams();
                SpawnDirectionPointer();

            }
        }

        float progress = Mathf.Clamp01(TimePassed / FireRate);
        progressBar.fillAmount = progress;  // Set UI fill amount

        Health = m_GameManager.Health;

        float LostHealth = Health / MaxHealth ;
        HealthBar.fillAmount = LostHealth;




       if (TimePassed > FireRate)
       {
            SpawnArrow();
            m_DirectionPointerActive = false;
            TimePassed = 0;
                
       }

       if (Health <= 0)
        {
            GameObject DeathAnimation = Instantiate(DeathAnimationPrefab, new Vector3(0f, -0.3f, 40f), Quaternion.identity);
            DeathAnimation.transform.SetParent(null);
            Debug.Log("DeathAnimation");

            m_GameManager.PlayerIsDead = true;



            Destroy(gameObject);
            //gameObject.SetActive(false);

        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.CompareTag("Enemy"))
            {
                EnemyScript enemy = collision.GetComponent<EnemyScript>(); // Get the Enemy script
                if (enemy != null)
                {
                    enemy.PlayerHit();

                }

            }

        }
    }



    private void LateUpdate()
    {

        if (ArrowDurationBar != null)
        {
            float progress = Mathf.Clamp01(ArrowScript.CurLifeTime / m_GameManager.MaxLifeTime);
            ArrowDurationBar.fillAmount = progress;
            
        }
    }



    private void NewSpawnParams()
    {

        float angle = Random.Range(0f, 360f);
        m_direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));


        m_spawnPosition = transform.position + (Vector3)m_direction * 0.2f;



        m_rotationAngle = Mathf.Atan2(m_direction.y, m_direction.x) * Mathf.Rad2Deg;
    }


    private void SpawnDirectionPointer()
    {
        GameObject DirectionPointerForNextArrow = Instantiate(DirectionPointerPrefab, m_spawnPosition, Quaternion.identity);
        
        DirectionPointerForNextArrow.transform.rotation = Quaternion.Euler(0f, 0f, m_rotationAngle - 90f); //-90f because the sprite is facing up instead of right
        m_DirectionPointerActive = true;
        Destroy(DirectionPointerForNextArrow, FireRate);

    }


    private void SpawnArrow()
    {
        {
            GameObject arrow = Instantiate(arrowPrefab, m_spawnPosition, Quaternion.identity);
            // Rotate arrow to face movement direction
            arrow.transform.rotation = Quaternion.Euler(0f, 0f, m_rotationAngle);
            ArrowActive = true;
        }
    }
}
