using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
	public float distance;

	public float attacktime;

	public int damage;

	void attack () {
		GameObject Player = GameObject.FindGameObjectWithTag ("Player");
		if (Vector3.Distance(Player.transform.position,transform.position)<distance)
			Player.GetComponentInChildren<Health> ().TakeDamage (damage);  
	} 

	// Use this for initialization
	void Start () {
		InvokeRepeating ("attack", 0f , attacktime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
