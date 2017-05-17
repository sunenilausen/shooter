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

		Vector3 rayOrigin = gunEnd.position;

		RaycastHit hit;

		laserLine.SetPosition (0, gunEnd.position);

		if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit)) {
			laserLine.SetPosition (1, hit.point);

			GameObject newObject = Instantiate (hitObject);
			newObject.transform.position = hit.point;
			newObject.GetComponent<ParticleSystem> ().Emit(50);
			
			if (hit.transform.gameObject.tag == "Shootable") {
				hit.transform.gameObject.SetActive (false);
			}
				
		}
		else {
			laserLine.SetPosition (1, rayOrigin + (fpsCam.transform.forward * weaponRange));
		}

		StartCoroutine (ShotEffect ());
	}

	IEnumerator ShotEffect() {
		laserLine.enabled = true;
		yield return shotDuration;

		laserLine.enabled = false;
	}
}
