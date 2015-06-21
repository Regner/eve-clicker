using UnityEngine;
using System.Collections;

public class UpgradeController : MonoBehaviour
{
    public GameObject weaponUpgradeButton;

    private GameController gameControllerScript;

    void Start()
    {
        GameObject gameController = GameObject.Find("Game Controller");
        gameControllerScript = gameController.GetComponent<GameController>();
    }
}