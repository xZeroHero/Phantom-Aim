using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePillarOnDeath : MonoBehaviour
{

    public GameManager m_GameManager;
    public SkilltreeSceneLoader m_SkilltreeSceneLoader;
    public float m_Speed;
    public Vector3 StartingPosition;
    public Vector3 StartingPositionSkillTree;
    public float StartDelay;
    public bool OpenScene = false;


    private float elapsedTime;
    private bool Reset = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = StartingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_GameManager.PlayerIsDead)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > StartDelay)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector3(-0.14f, -55f, -1f), m_Speed * Time.deltaTime);
                if (transform.position == new Vector3(-0.14f, -55f))
                {
                    SceneManager.LoadScene("SkillTree");
                    //m_GameManager.PlayerIsDead = false;
                    m_SkilltreeSceneLoader.LoadSkillTree();
                    m_GameManager.Health = m_GameManager.MaxHealth;
                }
            }
            else if(m_GameManager.ClearedLevel)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector3(-0.14f, -55f, -1f), m_Speed * Time.deltaTime);
                if (transform.position == new Vector3(-0.14f, -55f))
                {
                    SceneManager.LoadScene("SkillTree");
                    //m_GameManager.PlayerIsDead = false;
                    m_SkilltreeSceneLoader.LoadSkillTree();
                    m_GameManager.Health = m_GameManager.MaxHealth;
                }
            }
        }


        if (OpenScene)
        {
            SceneStart();
        }

    }


    public void NextLevel()
    {
        transform.position = StartingPosition;
        transform.position = Vector2.MoveTowards(transform.position, new Vector3(-0.14f, -55f, -1f), m_Speed * Time.deltaTime);
        if (transform.position == new Vector3(-0.14f, -55f))
        {
            SceneManager.LoadScene("Level1");
        }

    }


    public void ResetSceneStart()
    {
        transform.position = StartingPositionSkillTree;
        Reset = true;

    }
    public void SceneStart()
    {
        if(!Reset)
        {
            ResetSceneStart();
        }
        if (Reset)
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector3(-0.14f, 68f, -1f), m_Speed * 1.5f * Time.deltaTime);
        }

            if(transform.position.y >= new Vector3(-0.14f, 67f).y)
        {
            OpenScene = false;
            Reset = false;
            transform.position = StartingPosition;

        }

    }

    //IEnumerator Animation()
    //{
    //    while(!(transform.position == new Vector3(-0.14f, 67f, -1f)))
    //    {
    //        transform.position = Vector2.MoveTowards(transform.position, new Vector3(-0.14f, 67f, -1f), m_Speed * Time.deltaTime);
    //    }
    //    yield return null;
    //}
}
