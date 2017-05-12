using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {

	[SerializeField]
	private float speed = 0.5f;
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
		if (transform.position.x < -14f || transform.position.x > 9f) {
			Destroy (gameObject);
		}
	}
}
