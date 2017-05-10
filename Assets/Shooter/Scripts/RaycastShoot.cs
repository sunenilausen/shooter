using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour {

	public Transform gunEnd;
	private Camera fpsCam;

	// Use this for initialization
	void Start () {
		fpsCam = GetComponentInParent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Shoot();
		}
	}

	void Shoot () {
		Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0.0f));

		RaycastHit hit;

		if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit)) {
			hit.transform.gameObject.SetActive (false);
		}
	}

}
