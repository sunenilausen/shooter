using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour {

	public Transform gunEnd;
	private LineRenderer laserLine;
	private Camera fpsCam;
	public int weaponRange = 50;
	public WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
	private ParticleSystem gunParticles;
	public GameObject hitObject;
	public int damage = 2;

	// Use this for initialization
	void Start () {
		fpsCam = GetComponentInParent<Camera> ();
		laserLine = GetComponent<LineRenderer> ();
		gunParticles = gunEnd.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Shoot();
		}
	}

	void Shoot () {
		gunParticles.Emit (50);

		Vector3 rayOrigin = gunEnd.position - 1.2f*gunEnd.transform.forward;

		Vector3 shootorigin = gunEnd.position;

		RaycastHit hit;

		laserLine.SetPosition (0, gunEnd.position);

		if (Physics.Raycast(rayOrigin, gunEnd.transform.forward, out hit)) {
			laserLine.SetPosition (1, hit.point);

			GameObject newObject = Instantiate (hitObject);
			newObject.transform.position = hit.point;
			newObject.GetComponent<ParticleSystem> ().Emit(50);
			
			if (hit.transform.gameObject.tag == "Shootable") {
				var died =  hit.transform.gameObject.GetComponent<Health>().TakeDamage (damage);
				if (died) {
					GetComponentInParent <PointManager> ().AddPoint ();
				}

			}
				
		}
		else {
			laserLine.SetPosition (1, shootorigin + (gunEnd.transform.forward * weaponRange));
		}

		StartCoroutine (ShotEffect ());
	}

	IEnumerator ShotEffect() {
		laserLine.enabled = true;
		yield return shotDuration;

		laserLine.enabled = false;
	}
}
