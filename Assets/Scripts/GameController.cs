using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{

	// Public Variables

	// Enemy NPC Stuff
	public GameObject enemy;
	public Transform[] enemySpawnPoints;

	// Player Stuff
	public GameObject player;
	public Transform playerSpawnPoint;
	public int baseDamage;

	// UI Stuff
	public Text istText;
	public Text curreLevelText;
    public List<WeaponUpgradeController> weaponUpgradeControllers;

    // Level information
    public int currentLevel;

	// Private Variables
	private ulong currentIsk;
	private List<GameObject> spawnedEnemies;
	
	void Start ()
    {
        currentIsk = 10;
		spawnedEnemies = new List<GameObject>();
        weaponUpgradeControllers = new List<WeaponUpgradeController>();

		SpawnPlayer ();
		IncrementLevel ();
	}

	void Update ()
    {
		UpdateISKText ();
	}

	void IncrementLevel ()
    {
		currentLevel += 1;

		UpdateLevelText ();
		SpawnEnemies ();
	}

	void SpawnPlayer ()
    {
		Instantiate (player, playerSpawnPoint.position, playerSpawnPoint.rotation);
	}
	
	void SpawnEnemies ()
    {
		// We should never spawn enemies unless all are dead so confirm that first.
		if (spawnedEnemies.Count == 0) {
			foreach (Transform spawnPoint in enemySpawnPoints) {
				GameObject newEnemy = Instantiate (enemy, spawnPoint.position, spawnPoint.rotation) as GameObject;
				spawnedEnemies.Add (newEnemy);
			}
		}
	}

	void UpdateISKText ()
    {
		istText.text = "ISK:\n" + currentIsk;
	}

	void UpdateLevelText ()
    {
		curreLevelText.text = "Level:\n" + currentLevel;
	}

	public ulong GetDamageAmmount ()
    {
        ulong damageAmount = 0;

        foreach (WeaponUpgradeController weaponUpgrade in weaponUpgradeControllers)
        {
            damageAmount += weaponUpgrade.actualDamageAmount;
        }

        return damageAmount;
	}

	public void RemoveEnemy (GameObject enemyToDie)
    {
		spawnedEnemies.Remove (enemyToDie);

		if (spawnedEnemies.Count <= 0) {
			IncrementLevel ();
		}
	}

    public void AddISK(ulong iskToAdd)
    {
        currentIsk += iskToAdd;
        UpdateISKText ();
    }

    public void RemoveISK(ulong iskToRemove)
    {
        currentIsk -= iskToRemove;
        UpdateISKText();
    }

    public ulong CurrentISK()
    {
        return currentIsk;
    }
}
