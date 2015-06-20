using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

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

	// Private Variables
	private long isk;
	private int currentLevel;
	private List<GameObject> spawnedEnemies;
	
	void Start () {
		spawnedEnemies = new List<GameObject> ();

		// Testing shit, go away
		isk = 100000000000000;

		SpawnPlayer ();
		IncrementLevel ();
	}

	void Update () {
		UpdateISKText ();
	}

	void IncrementLevel () {
		currentLevel += 1;

		UpdateLevelText ();
		SpawnEnemies ();
	}

	void SpawnPlayer () {
		Instantiate (player, playerSpawnPoint.position, playerSpawnPoint.rotation);
	}
	
	void SpawnEnemies () {
		// We should never spawn enemies unless all are dead so confirm that first.
		if (spawnedEnemies.Count == 0) {
			foreach (Transform spawnPoint in enemySpawnPoints) {
				GameObject newEnemy = Instantiate (enemy, spawnPoint.position, spawnPoint.rotation) as GameObject;
				spawnedEnemies.Add (newEnemy);
			}
		}
	}

	void UpdateISKText () {
		istText.text = "ISK:\n" + isk;
	}

	void UpdateLevelText () {
		curreLevelText.text = "Level:\n" + currentLevel;
	}

	public int GetDamageAmmount () {
		return baseDamage;
	}

	public void RemoveEnemy (GameObject enemyToDie) {
		spawnedEnemies.Remove (enemyToDie);

		if (spawnedEnemies.Count <= 0) {
			IncrementLevel ();
		}
	}
}
