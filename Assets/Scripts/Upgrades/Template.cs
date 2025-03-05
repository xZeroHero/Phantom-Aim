using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Template : MonoBehaviour
{

    //public Button m_Button;
    public UpgradeManager m_UpgradeManager;
    public GameManager m_GameManager;
    public TextMeshProUGUI SpiritCost;
    public TextMeshProUGUI TimesBought;


    public int m_CurrentSpirit;
    public int m_BuyLimit;
    public int[] m_SpiritCostList;
    public int m_TimesUpgraded;

    public void Start()
    {

        m_UpgradeManager.ArrowSpeedUpgradeLimit = m_SpiritCostList.Length;   //TODO: Change
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

    public void UpgradeArrowSpeed()
    {

        UpdateButton();
        if (m_TimesUpgraded <  m_BuyLimit && m_SpiritCostList[m_TimesUpgraded] <= m_CurrentSpirit)
        {
            //Update Stats
            m_GameManager.ArrowSpeed += m_UpgradeManager.ArrowSpeedModifier;        //TODO: Change

            //RemoveSpirit
            m_GameManager.Spirit -= m_SpiritCostList[m_TimesUpgraded];

            //Update Upgrades Bought
            m_UpgradeManager.ArrowSpeedUpgrades++;                                  //TODO: Change

            UpdateButton();
        }
    }

    public void UpdateButton()
    {

        m_CurrentSpirit = m_GameManager.Spirit;
        m_BuyLimit = m_UpgradeManager.ArrowSpeedUpgradeLimit;                       //TODO: Change
        m_TimesUpgraded = m_UpgradeManager.ArrowSpeedUpgrades;                      //TODO: Change


        SetSpiritCost();
        SetTimesBought();
    }
}
