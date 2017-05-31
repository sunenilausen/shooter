using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	int health;
	public int maxHealth; 

	// Use this for initialization
	void Start () {
		health = maxHealth;
	}

	public bool TakeDamage(int amount) {
		health -= amount;

		if (health <= 0) {
			
			gameObject.SetActive (false);
			return true;
		}

		return false;
	}
}
