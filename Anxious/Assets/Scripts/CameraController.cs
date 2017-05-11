using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float horizontalSpeed = 200f;
	public float verticalSpeed = 200f;

	void Update() {
		float h = horizontalSpeed * Input.GetAxis ("Mouse X");
		transform.Rotate(0, h, 0);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
	}
}
