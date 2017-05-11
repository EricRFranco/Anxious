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
	[SerializeField]
	private float _hideTime = 5f;
	private float _addTime = 2f;
	private GameObject [] _hidingSpots;
	private List<GameObject> _filterHidden;
	private float z;

	private void Awake() {
		z = transform.position.z;
		_hidingSpots = GameObject.FindGameObjectsWithTag ("Hide");
		_filterHidden = new List<GameObject> ();
		foreach (GameObject go in _hidingSpots) {
			_filterHidden.Add (go);
		}
		isHidden = false;
	}

	private void Update() {
		
		Transform closest = ClosestHidingPlace (_filterHidden).transform;
		if (Input.GetMouseButton (0)) {
			isHidden = true;
			transform.position = Vector3.MoveTowards (transform.position, closest.position, speed * Time.deltaTime);
			if (transform.position == closest.position) {
				_hideTime -= Time.deltaTime;
				if (_hideTime <= 0) {
					confidence.ChangeConfidence (-5);
					_hideTime = 5f;
				} else {
					_addTime -= Time.deltaTime;
					if (_addTime <= 0) {
						confidence.ChangeConfidence (2f);
						_addTime = 2f;
					}
				}
			}
		} else if (!Input.GetMouseButton (0) && transform.position.z != z) {
			isHidden = false;
			_hideTime = 5f;
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, transform.position.y, z), speed * Time.deltaTime);
		}

		if (!isHidden) {
			FilterHidingSpots ();
			if (transform.position.z != z)
				transform.Translate (Vector3.forward * speed * Time.deltaTime);
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
		
}
