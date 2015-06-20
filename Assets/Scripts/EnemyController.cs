using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public int health;

	private GameController gameControllerScript;

	void Start () {
		GameObject gameController = GameObject.Find ("Game Controller");
		gameControllerScript = gameController.GetComponent<GameController> ();
		
		UpdateHealthText ();
	}
	
	void OnMouseUp () {
		int damage = gameControllerScript.GetDamageAmmount();
		DamageTaken (damage);
	}

	void DamageTaken (int damage) {
		health -= damage;
		Debug.Log ("Enemy lost " + damage + " HP. Now has " + health + " HP remaining.");

		if (health <= 0) {
			Destroy (gameObject);
		}

		UpdateHealthText ();
	}

	void UpdateHealthText () {
		gameObject.GetComponentInChildren<TextMesh>().text = "" + health;
	}

	void OnDestroy () {
		Debug.Log ("Health equal to or below 0. Death.");
		gameControllerScript.RemoveEnemy (gameObject);
	}
}