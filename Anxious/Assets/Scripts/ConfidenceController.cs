using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfidenceController : MonoBehaviour {

	private Slider _confidence;
	private float _currentConfidence = 100f;

	private void Awake() {
		_confidence = GetComponent<Slider> ();
	}

	private void Update() {
		_confidence.value = _currentConfidence;
	}

	public void ChangeConfidence (float dC) {
		_currentConfidence += dC;
	}
	
}
