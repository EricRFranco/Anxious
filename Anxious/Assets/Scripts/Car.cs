using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	public float speed;
	// Update is called once per frame
	void Update () {
		if (transform.position.z > 4f)
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		else
			transform.Translate (Vector3.forward * speed * Time.deltaTime);

		if (transform.position.x < -14f || transform.position.x > 9f) {
			Destroy (gameObject);
		}
	}
}
