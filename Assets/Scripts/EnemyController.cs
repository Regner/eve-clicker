using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public int baseHealth;
    public int baseISK;

    private ulong actualHealth;
    private ulong actualISK;

	private GameController gameControllerScript;

	void Start ()
    {
		GameObject gameController = GameObject.Find ("Game Controller");
		gameControllerScript = gameController.GetComponent<GameController> ();

        CalculateEnempyHP();
        CalculateEnemyISK();

		UpdateHealthText ();
	}
	
	void OnMouseUp ()
    {
		ulong damage = gameControllerScript.GetDamageAmmount();
		DamageTaken (damage);
	}

	void DamageTaken (ulong damage)
    {

        if (damage < actualHealth)
        {
            actualHealth -= damage;
            UpdateHealthText();
		}
        else
        {
            Destroy(gameObject);
        }
	}

	void UpdateHealthText ()
    {
        gameObject.GetComponentInChildren<TextMesh>().text = "" + actualHealth;
	}

	void OnDestroy ()
    {
		gameControllerScript.RemoveEnemy (gameObject);
        gameControllerScript.AddISK (actualISK);
	}

    void CalculateEnempyHP()
    {
        actualHealth = (uint)Mathf.Round(baseHealth * Mathf.Pow(1.5f, gameControllerScript.currentLevel - 1));
    }

    void CalculateEnemyISK()
    {
        actualISK = (ulong)Mathf.Round(baseISK * Mathf.Pow(1.15f, gameControllerScript.currentLevel - 1));
    }
}