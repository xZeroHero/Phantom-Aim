using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArmorPierceUpgrade : MonoBehaviour
{

    //public Button m_Button;
    public UpgradeManager m_UpgradeManager;
    public GameManager m_GameManager;
    public TextMeshProUGUI SpiritCost;
    public TextMeshProUGUI TimesBought;
    public GameObject SkillUnchecked;
    public GameObject SkillChecked;
    public GameObject[] SkillCheckmarks;



    public int m_CurrentSpirit;
    public int m_BuyLimit;
    public int[] m_SpiritCostList;
    public int m_TimesUpgraded;

    public void Start()
    {

        m_UpgradeManager.ArmorPierceUpgradeLimit = m_SpiritCostList.Length;   
        UpdateButton();

    }

    public void SetSpiritCost()
    {
        //Debug.Log("Set Spirit Cost" + m_SpiritCostList);

        if (m_TimesUpgraded < m_BuyLimit)
        {
            SpiritCost.text = m_SpiritCostList[m_TimesUpgraded].ToString();
        }
        else
        {
            SpiritCost.text = "---";
        }

    }

    public void SetTimesBought()
    {
        TimesBought.text = m_TimesUpgraded.ToString() + "/" + m_BuyLimit.ToString();
    }

    public void UpgradeArmorPierce()
    {

        UpdateButton();
        if (m_TimesUpgraded <  m_BuyLimit && m_SpiritCostList[m_TimesUpgraded] <= m_CurrentSpirit)
        {
            //Update Stats
            //m_GameManager.ArmorPierce += m_UpgradeManager.ArmorPierceModifier;       

            //RemoveSpirit
            m_GameManager.Spirit -= m_SpiritCostList[m_TimesUpgraded];

            //Update Upgrades Bought
            m_UpgradeManager.ArmorPierceUpgrades++;  
            m_UpgradeManager.CalculateStats();


            UpdateButton();
        }
    }

    public void UpdateButton()
    {

        m_CurrentSpirit = m_GameManager.Spirit;
        m_BuyLimit = m_UpgradeManager.ArmorPierceUpgradeLimit;                       
        m_TimesUpgraded = m_UpgradeManager.ArmorPierceUpgrades;                      


        SetSpiritCost();
        SetTimesBought();
        InstantiateSkillCheckmarks();

    }

    public void SetSkillCheckmarks()
    {
        int Length = m_BuyLimit;
        int Bought = m_TimesUpgraded;
        SkillCheckmarks = new GameObject[m_BuyLimit];

        for (int i = 0; i < Length; i++)
        {
            if (Bought > 0)
            {
                SkillCheckmarks[i] = SkillChecked;
                Bought--;
                Debug.Log("skillChecked Set");
            }
            else
            {
                SkillCheckmarks[i] = SkillUnchecked;
                Debug.Log("SkillUnchecked Set");

            }
        }

    }

    public void InstantiateSkillCheckmarks()
    {
        // Remove only skill checkmarks, keeping other children intact
        foreach (Transform child in transform)
        {
            if (child.CompareTag("SkillCheckmarks"))
            {
                Destroy(child.gameObject);
            }
        }
        SetSkillCheckmarks();
        int x = 100;

        for (int i = 0; i < SkillCheckmarks.Length; i++)
        {
            Debug.Log("Instantiate for loop: " + i);

            GameObject Checkmark = Instantiate(SkillCheckmarks[i], new Vector3(x, 2f), Quaternion.identity);
            Checkmark.tag = "SkillCheckmarks";
            Checkmark.transform.SetParent(transform, false);

            x += 75;
        }


    }
}
