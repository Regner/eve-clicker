using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponUpgradeController : MonoBehaviour {

    public bool isPrePurchased;
    public int baseDamageAmount;
    public ulong baseUpgradeCost;
    public ulong actualDamageAmount;
    public float damageUpgradePercentage;

    private GameController gameControllerScript;
    private int currentUpgradeLevel;
    private Text currentLevelText;
    private Text nextLevelCostText;
    private Text currentDamageText;
    private Text nextLevelDamageText;

    void Start()
    {
        GameObject gameController = GameObject.Find("Game Controller");
        gameControllerScript = gameController.GetComponent<GameController>();

        gameControllerScript.weaponUpgradeControllers.Add(this);

        currentLevelText = transform.FindChild("Current Level Text").GetComponent<Text>();
        nextLevelCostText = transform.FindChild("Next Level Text").GetComponent<Text>();
        currentDamageText = transform.FindChild("Current Damage Text").GetComponent<Text>();
        nextLevelDamageText = transform.FindChild("Next Level Damage Text").GetComponent<Text>();

        UpdateTextFields();

        
    }

    ulong CalculateUpgradeCost()
    {
        return baseUpgradeCost * (ulong)Mathf.Pow(2, currentUpgradeLevel);
    }

    ulong CalculateNextLevelDamage()
    {
        //return (ulong)Mathf.Round(baseDamageAmount * Mathf.Pow(damageUpgradePercentage, currentUpgradeLevel));
        return actualDamageAmount + 1;
    }

    public void UpgradeWeaponLevel()
    {
        if (gameControllerScript.CurrentISK() >= CalculateUpgradeCost())
        {
            gameControllerScript.RemoveISK(CalculateUpgradeCost());
            actualDamageAmount = CalculateNextLevelDamage();
            currentUpgradeLevel += 1;

            UpdateTextFields();
        }
    }

    void UpdateTextFields()
    {
        UpdateCurrentLevelText();
        UpdateNextLevelCostText();
        UpdateCurrentDamageText();
        UpdateNextLevelDamageText();
    }

    void UpdateCurrentLevelText()
    {
        currentLevelText.text = currentUpgradeLevel.ToString();
    }

    void UpdateNextLevelCostText()
    {
        nextLevelCostText.text = CalculateUpgradeCost().ToString();
    }

    void UpdateCurrentDamageText()
    {
        currentDamageText.text = actualDamageAmount.ToString();
    }

    void UpdateNextLevelDamageText()
    {
        nextLevelDamageText.text = CalculateNextLevelDamage().ToString();
    }
}
