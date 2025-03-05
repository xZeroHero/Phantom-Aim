using UnityEngine;
using TMPro;

public class SpiritDropScript : MonoBehaviour
{

    public AnimationCurve Curve;
    public GameManager m_GameManager;
    public GameObject SpiritGainPrefab;
    public float Speed;
    public float StartDelay;
    public int SpiritValue;

    private float m_ElapsedTime;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_ElapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_ElapsedTime += Time.deltaTime;

        if (m_ElapsedTime > StartDelay)
        {
            Speed += Curve.Evaluate(m_ElapsedTime / Speed);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), Speed * Time.deltaTime);

            

            //transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), Speed * Time.deltaTime);
            //Speed += Speed;

            if (transform.position == new Vector3(0, 0, 0))
            {
                InstantiateSpiritGain();


                AddSpiritToBank(SpiritValue);
                Destroy(gameObject);
            }
        }
    }

    public void InstantiateSpiritGain()
    {
        GameObject SpiritGainObject = (Instantiate(SpiritGainPrefab, gameObject.transform));
        SpiritGainObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>().SetText(SpiritValue.ToString());
        SpiritGainObject.transform.SetParent(null);
    }

    public void SetSpiritValue(int Value)
    {
        SpiritValue = Value;
    }

    public void AddSpiritToBank(int Value)
    {
        m_GameManager.Spirit += SpiritValue;
    }
}
