using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	[HideInInspector]
	public bool isHidden = false;
	public ConfidenceController confidence;
	public float speed = 2f;

	[SerializeField]
	private float _timeLeft = 3f;
	//private GameObject [] _hidingSpots;

	void Awake() {
		//_hidingSpots = GameObject.FindGameObjectsWithTag ("Hide");
	}

	void Update() {
		if (!isHidden) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
			_timeLeft -= Time.deltaTime;
			if (_timeLeft <= 0) {
				confidence.ChangeConfidence (-5);
				_timeLeft = 3f;
			}
		}
	}
}
