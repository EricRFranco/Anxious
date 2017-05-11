using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Player : MonoBehaviour {

	[HideInInspector]
	public bool isHidden;
	public ConfidenceController confidence;
	public float speed = 2f;

	[SerializeField]
	private float _timeLeft = 3f;
	private GameObject [] _hidingSpots;
	private List<GameObject> _filterHidden;

	private void Awake() {
		_hidingSpots = GameObject.FindGameObjectsWithTag ("Hide");
		_filterHidden = new List<GameObject> ();
		foreach (GameObject go in _hidingSpots) {
			_filterHidden.Add (go);
		}
		isHidden = false;
	}

	private void Update() {
		FilterHidingSpots ();

		Transform closest = ClosestHidingPlace (_filterHidden).transform;
		if (Input.GetMouseButton (0) && transform.position.x == closest.position.x) {
			isHidden = true;
			StartCoroutine ("DelayCountdown");
			transform.position = Vector3.MoveTowards (transform.position, closest.position, speed * Time.deltaTime);
		} else if (!Input.GetMouseButton (0)) {
			isHidden = false;
		}

		if (!isHidden) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
			_timeLeft -= Time.deltaTime;
			if (_timeLeft <= 0) {
				confidence.ChangeConfidence (-5);
				_timeLeft = 3f;
			}
		} 


	}

	private void FilterHidingSpots () {
		foreach (GameObject go in _filterHidden) {
			if (go.transform.position.x < transform.position.x) {
				_filterHidden.Remove (go);
			}

		}
		print (_filterHidden.Count);
	}

	private GameObject ClosestHidingPlace(List<GameObject> hide) {
		List<float> distances = new List<float> ();
		int minIndex;
		foreach(GameObject go in hide) {
			distances.Add(Vector3.Distance (transform.position, go.transform.position));
		}

		minIndex = distances.IndexOf (distances.Min());
		return hide [minIndex];

	}

	private IEnumerator DelayCountdown () {
		yield return new WaitForSeconds (5);
		confidence.ChangeConfidence (-5);
	}
}
