using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfidenceController : MonoBehaviour {

	private Slider _confidence;
	private int _currentConfidence = 100;
	private float _timeLeft = 3f;

	void Awake () {
		
		_confidence = GetComponent<Slider> ();

		}

	void Update() {

		_confidence.value = _currentConfidence;
		_timeLeft -= Time.deltaTime;
		if (_timeLeft <= 0) {
			ChangeConfidence (-5);
			_timeLeft = 30;
		}

	}

	public void ChangeConfidence (int dC) {
		
		_currentConfidence += dC;

	}
	
}
