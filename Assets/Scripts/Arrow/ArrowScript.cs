
using UnityEngine;


public class ArrowScript : MonoBehaviour
{

    public GameManager m_GameManager;
    public static float CurLifeTime;
    public LayerMask EnemyLayer;
    public float FreezeDuration;

    //Out of screen Pointers
    public GameObject PointerUp;
    public GameObject PointerRight;
    public GameObject PointerDown;
    public GameObject PointerLeft;
    public GameObject PointerPrefab;



    private float m_ArrowSpeed;
    private float m_MaxLifeTime;
    private float m_RotationSpeed;
    private float m_ArrowDamage;
    //private bool m_IsFrozen;
    private float m_ArmorPierce;

    private GameObject activePointer;

    private Camera m_MainCamera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurLifeTime = 0;
        m_ArrowSpeed = m_GameManager.ArrowSpeed;
        m_MaxLifeTime = m_GameManager.MaxLifeTime;
        m_RotationSpeed = m_GameManager.RotationSpeed;
        m_ArrowDamage = m_GameManager.ArrowDamage;
        //m_IsFrozen = false;
        m_ArmorPierce = m_GameManager.ArmorPierce;

}

    // Update is called once per frame
    private void Update()
    {
        //TrackArrow();

        //Destroy Arrow after MaxLifeTime is reached
        CurLifeTime += Time.deltaTime;
        //Debug.Log(CurLifeTime + " | " + Time.deltaTime);
        if (CurLifeTime > m_MaxLifeTime || Input.GetKeyDown("space"))
        {

            //Debug.Log("ActivePointershould be ");
            //Destroy(activePointer);

            KillArrow();
        }
        FlyToMouse();



        if (!GetComponent<Renderer>().isVisible)
        {
            //Debug.Log("Arrow out of Screen");
            TrackArrow();
        }
        else if (activePointer != null) //Destroys Pointer if Arrow is in Screen and Pointer exists
        {
            Destroy(activePointer);
            activePointer = null; // Prevent multiple destroy calls
        }

    }

    public void KillArrow()
    {

        // Destroy pointer if it exists
        if (activePointer != null)
        {
            Debug.Log("Pointer should now begin to be destroyed");
            Destroy(activePointer.gameObject);
            activePointer = null;
            Debug.Log("Pointer should now be destroyed");
        }

        Destroy(gameObject);


        PlayerScript.ArrowActive = false;
    }

    public void FlyToMouse()
    {
        //Get Vector3 of current mouse position
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);


        // Smoothly rotate towards the mouse position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, m_RotationSpeed * Time.deltaTime);

        // Move forward in the direction the object is facing
        transform.position += transform.right * m_ArrowSpeed * Time.deltaTime;


       
    }

    

    private void TrackArrow()
    {
        if (m_MainCamera == null) m_MainCamera = Camera.main;

        Vector3 arrowViewportPos = m_MainCamera.WorldToViewportPoint(transform.position);

        if (PlayerScript.ArrowActive)
        {
            // Clamp pointer position inside the camera bounds
            float clampedX = Mathf.Clamp(arrowViewportPos.x, 0.03f, 0.97f);
            float clampedY = Mathf.Clamp(arrowViewportPos.y, 0.03f, 0.97f);
            Vector3 pointerViewportPos = new Vector3(clampedX, clampedY, arrowViewportPos.z);
            Vector3 pointerWorldPos = m_MainCamera.ViewportToWorldPoint(pointerViewportPos);

            // If pointer already exists, update its position
            if (activePointer != null)
            {
                activePointer.transform.position = pointerWorldPos;
            }
            else
            {
                // Instantiate a pointer at the clamped position
                activePointer = Instantiate(PointerPrefab, pointerWorldPos, Quaternion.identity);
            }


            // Make the pointer face away from the center
            Vector3 direction = (activePointer.transform.position - Vector3.zero).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            activePointer.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }


    private void SetPointer(GameObject pointerPrefab, Vector3 spawnPosition)
    {
        // Destroy previous pointer if it exists
        if (activePointer != null)
        {
            Destroy(activePointer);
        }

        // Instantiate a new pointer and track it
        activePointer = Instantiate(pointerPrefab, spawnPosition, Quaternion.identity);
    }


    private void SpawnOutOfscreenPointer()
    {
        m_MainCamera = Camera.main;


        Vector3 arrowScreenPos = m_MainCamera.WorldToScreenPoint(transform.position);

        if (arrowScreenPos.y > Screen.height)
        {
            Debug.Log("Arrow is above vertical camera view! y+");
        }
        
        if (arrowScreenPos.y < 0)
        {
            Debug.Log("Arrow is below vertical camera view! y-");
        }

        if(arrowScreenPos.x > Screen.width)
        {
            Debug.Log("Arrow is right of horizontal camera view! x+");
        }

        if (arrowScreenPos.x < 0)
        {
            Debug.Log("Arrow is left of horizontal camera view! x-");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.CompareTag("Enemy"))
            {
                EnemyScript enemy = collision.GetComponent<EnemyScript>(); // Get the Enemy script
                if (enemy != null)
                {
                    enemy.EnemyHit(m_ArrowDamage); // Call TakeDamage method


                    float NewCurLifeTime = CurLifeTime + 1 - enemy.EnemyPierceModifier(m_ArmorPierce);

                    if (NewCurLifeTime > m_MaxLifeTime)
                    {
                        CurLifeTime = m_MaxLifeTime - 0.01f;
                    }
                    else
                    {
                        CurLifeTime = NewCurLifeTime;
                    }

                    

                }

            }

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
        }
    }


}
