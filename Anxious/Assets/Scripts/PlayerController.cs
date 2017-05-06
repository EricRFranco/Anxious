using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 2f;
	GameObject player;

	void Start() {
		player = this.gameObject;
	}

	void Update() {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
}
