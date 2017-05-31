using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	int health;
	public int maxHealth; 

	// Use this for initialization
	void Start () {
		health = maxHealth;
	}

	public void TakeDamage(int amount) {
		health -= amount;

		if (health <= 0)
			gameObject.SetActive (false);
	}
}
